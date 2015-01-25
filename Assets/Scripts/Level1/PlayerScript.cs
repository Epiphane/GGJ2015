﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerScript : MonoBehaviour {

	private const float MOVE_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
		GamePad.SetVibration(0, 1, 1);
	}

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	// Update is called once per frame
	void Update () {
//		float moveHorizontal = Input.GetAxis("Horizontal");
//		float moveVertical = Input.GetAxis("Vertical");
//		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
//		transform.Translate(translate);

		Debug.Log ("horiz1:" + Input.GetAxis("Horizontal1") + "horiz2: " + Input.GetAxis("Horizontal2"));
		if (Input.GetKey (up))
		{
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.up * Time.deltaTime * 100, transform.localPosition);
		}
		if (Input.GetKey (down))
		{    
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.down * Time.deltaTime * 100, transform.localPosition);
		}  
		if (Input.GetKey (right))
		{
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.right * Time.deltaTime * 100, transform.localPosition);
		}
		if (Input.GetKey (left))
		{    
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.left * Time.deltaTime * 100, transform.localPosition);
		}  
	}
}
