﻿using UnityEngine;
using System.Collections;

public class FlappyScript : MonoBehaviour {
	
	bool alive;
	bool frozen;
	public float gravityScale;

	CountdownScript countdownScript;

	// Use this for initialization
	void Start () {
		alive = true;
		rigidbody2D.gravityScale = 0;
		frozen = true;

		countdownScript = GameObject.Find("Countdown").GetComponent<CountdownScript>();
	}

	public int playerNum;

	// Update is called once per frame
	void Update () {
		if (!alive) {
			return;
		}

		if (frozen) {
			if (countdownScript.Done ()) {
				frozen = false;
				rigidbody2D.gravityScale = gravityScale;
			}
		}

		if (GlobalInput.players[playerNum].ABtn()) {
			Vector2 vel = rigidbody2D.velocity;
			vel.y = 0;
			rigidbody2D.velocity = vel;
			rigidbody2D.AddForce(Vector2.up * 300.0f);
		}

		rigidbody2D.AddForce(Vector2.right * GlobalInput.players[playerNum].XAxis() * 5.0f);
	}

	public void OnHitPipe() {
		alive = false;
	
		rigidbody2D.gravityScale = gravityScale;

		GameObject leftInvis = GameObject.Find("Left Invisible Wall");
		GameObject rightInvis = GameObject.Find("Right Invisible Wall");
		Physics2D.IgnoreCollision(collider2D, leftInvis.collider2D);
		Physics2D.IgnoreCollision(collider2D, rightInvis.collider2D);
	}

	public bool IsAlive() {
		return alive;
	}
}
