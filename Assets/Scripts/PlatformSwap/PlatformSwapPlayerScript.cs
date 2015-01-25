using UnityEngine;
using System.Collections;

public class PlatformSwapPlayerScript : MonoBehaviour {

	const float MOVE_SPEED = 5.0f;

	public string player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizAxis = Input.GetAxis(player + "_Horizontal_keyboard");
		rigidbody2D.velocity = new Vector2(horizAxis * MOVE_SPEED, rigidbody2D.velocity.y);

		float jump = Input.GetKey(KeyCode.Space) ? 50.0f : 0.0f;
		rigidbody2D.AddForce(Vector2.up * jump);
	}
}
