using UnityEngine;
using System.Collections;

public class FlappyScript : MonoBehaviour {
	
	bool alive;

	// Use this for initialization
	void Start () {
		alive = true;
	}

	public int playerNum;

	// Update is called once per frame
	void Update () {
		if (!alive) {
			return;
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
	}

	public bool IsAlive() {
		return alive;
	}
}
