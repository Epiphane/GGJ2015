using UnityEngine;
using System.Collections;

public class PlatformSwapPlayerScript : MonoBehaviour {

	const float MOVE_SPEED = 5.0f;

	public int playerNum;

	private bool onGround;
	CountdownScript countdownScript;
	int playerIndex;

	// Use this for initialization
	void Start () {
		onGround = true;
		countdownScript = GameObject.Find("Countdown").GetComponent<CountdownScript>();

		if (playerNum == 1) {
			playerIndex = GameController.instance.GetPlayerOne();
		}
		if (playerNum == 2) {
			playerIndex = GameController.instance.GetPlayerTwo();
		}
		if (playerNum == 3) {
			playerIndex = GameController.instance.GetPlayerThree();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!countdownScript.Done()) {
			return;
		}

		float horizAxis = GlobalInput.players[playerIndex].XAxis();
		rigidbody2D.velocity = new Vector2(horizAxis * MOVE_SPEED, rigidbody2D.velocity.y);

		if (onGround && GlobalInput.players[playerIndex].ABtn()) {
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
