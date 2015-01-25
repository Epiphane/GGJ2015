﻿using UnityEngine;
using System.Collections;

public class FlappyScript : MonoBehaviour {

	bool flapHeld;
	bool alive;

	// Use this for initialization
	void Start () {
		flapHeld = false;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!alive) {
			return;
		}

		if (Input.GetKey(KeyCode.Space) && !flapHeld) {
			flapHeld = true;
			Vector2 vel = rigidbody2D.velocity;
			vel.y = 0;
			rigidbody2D.velocity = vel;
			rigidbody2D.AddForce(Vector2.up * 300.0f);
		}

		flapHeld = Input.GetKey(KeyCode.Space);
	}

	public void OnHitPipe() {
		alive = false;
	}

	public bool IsAlive() {
		return alive;
	}
}
