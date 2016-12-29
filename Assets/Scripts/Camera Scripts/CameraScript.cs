using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    private static float EASY_SPEED = 3.2f;
    private static float MEDIUM_SPEED = 3.8f;
    private static float HARD_SPEED = 4.4f;

    [HideInInspector]
    public bool moveCamera;

	// Use this for initialization
	void Start () {

        if (GamePreferences.IsHardDifficulty()) {
            maxSpeed = HARD_SPEED;
        } else if (GamePreferences.IsMediumDifficulty()) {
            maxSpeed = MEDIUM_SPEED;
        } else if (GamePreferences.IsEasyDifficulty()) {
            maxSpeed = EASY_SPEED;
        }

        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveCamera) {
            MoveCamera();
        }
	}

    void MoveCamera() {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed) {
            speed = maxSpeed;
        }
    }

}
