using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static float SPEED = 8f;
	public static float MAX_VELOCITY = 4f;

	private Rigidbody2D body;
	private Animator animator;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard() {
		float forceX = 0f;
		float vel = Mathf.Abs (body.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			// Limit player walking speed
			if (vel < MAX_VELOCITY) {
				forceX = SPEED;
			}

			//Start walk animation
			animator.SetBool ("Walk", true);

			// Change player direction
			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;
		} else if (h < 0) {
			// Limit player walking speed
			if (vel < MAX_VELOCITY) {
				forceX = -SPEED;
			}

			//Start walk animation
			animator.SetBool ("Walk", true);

			// Change player direction
			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;
		} else {
			// Stop walk animation
			animator.SetBool ("Walk", false);
		}
			
		body.AddForce (new Vector2 (forceX, 0));

	}
}
