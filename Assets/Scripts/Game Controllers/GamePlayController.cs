using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {
    
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    private void Awake() {
        MakeInstance();
        if (readyButton != null)
            readyButton.SetActive(true);
        SetScoreLabelsText(PlayerScore.GetScoreCount(), PlayerScore.GetCoinCount(), PlayerScore.GetLifeCount());
    }

    public void SetScoreLabelsText(int score, int coin, int life) {
        SetScore(score);
        SetCoinScore(coin);
        SetLifeScore(life);
    }

    public void SetScore(int score) {
        scoreText.text = score.ToString();
    }
	
    public void SetCoinScore(int coinScore) {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore) {
        lifeText.text = "x" + lifeScore;
    }

	void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    IEnumerator GameOverLoadMainMenu() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PlayerDiedRestart() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GamePlay");
    }

    public void PlayerDiedRestartGame() {
        StartCoroutine(PlayerDiedRestart());
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore) {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    private void Start() {
        Time.timeScale = 0f;
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame() {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }

}
