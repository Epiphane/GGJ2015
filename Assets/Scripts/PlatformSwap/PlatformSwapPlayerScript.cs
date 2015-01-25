using UnityEngine;
using System.Collections;

public class PlatformSwapPlayerScript : MonoBehaviour {

	const float MOVE_SPEED = 5.0f;

	public int playerNum;

	private bool onGround;

	// Use this for initialization
	void Start () {
		onGround = true;
	}
	
	// Update is called once per frame
	void Update () {
		float horizAxis = GlobalInput.players[playerNum].XAxis();
		rigidbody2D.velocity = new Vector2(horizAxis * MOVE_SPEED, rigidbody2D.velocity.y);

		if (onGround && GlobalInput.players[playerNum].ABtn()) {
			onGround = false;
			rigidbody2D.AddForce(Vector2.up * 450.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if ((other.gameObject.tag.Equals("floor") || other.gameObject.tag.Equals("swapPlatform")) && other.transform.position.y < transform.position.y) {
			onGround = true;
		}
	}
}
