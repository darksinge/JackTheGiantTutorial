using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip coinCLip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool canCountScore;

    private static int scoreCount;
    private static int lifeCount;
    private static int coinCount;

    private GamePlayController gameInstance;

    void Awake() {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    void Start () {
        previousPosition = transform.position;
        gameInstance = GamePlayController.instance;
        canCountScore = true;
    }
	
	void Update () {
        CountScore();
	}

    public static void SetScoreCount(int count) { scoreCount = count; }

    public static void SetLifeCount(int count) {
        lifeCount = count;
        if (lifeCount < 0)
            lifeCount = 0;
    }

    public static void SetCoinCount(int count) { coinCount = count; }

    public static int GetScoreCount() { return scoreCount; }

    public static int GetLifeCount() { return lifeCount; }

    public static int GetCoinCount() { return coinCount; }

    void CountScore() {
        if (canCountScore) {
            if (transform.position.y < previousPosition.y) {
                gameInstance.SetScore(scoreCount++);
            }
        }
        previousPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        
        if (target.tag == "Coin") {
            scoreCount += 200;
            coinCount++;
            gameInstance.SetScore(scoreCount);
            gameInstance.SetCoinScore(coinCount);
            
            AudioSource.PlayClipAtPoint(coinCLip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life") {
            scoreCount += 300;
            lifeCount++;
            gameInstance.SetScore(scoreCount);
            gameInstance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        // If player hits bad
        if (target.tag == "Bounds" || target.tag == "Deadly") {

            cameraScript.moveCamera = false;
            canCountScore = false;
            lifeCount--;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

            transform.position = new Vector3(500, 500, 0);

            Debug.Log("Player Died!");
        }

    }
   

}
