using UnityEngine;
using System.Collections;

public class PlatformSwapPlayerScript : MonoBehaviour {

	const float MOVE_SPEED = 5.0f;

	public string player;

	private bool onGround;

	// Use this for initialization
	void Start () {
		onGround = true;
	}
	
	// Update is called once per frame
	void Update () {
		float horizAxis = Input.GetAxis(player + "_Horizontal_keyboard");
		rigidbody2D.velocity = new Vector2(horizAxis * MOVE_SPEED, rigidbody2D.velocity.y);

		if (onGround && Input.GetKey(KeyCode.Space)) {
			onGround = false;
			rigidbody2D.AddForce(Vector2.up * 450.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag.Equals("floor") && other.transform.position.y < transform.position.y) {
			onGround = true;
		}
	}
}
