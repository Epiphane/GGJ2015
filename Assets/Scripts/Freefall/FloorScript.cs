using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	public bool good;

	private LevelController levelController;
	private GameObject player1, player2, player3;
	bool hitPlayer1, hitPlayer2, hitPlayer3;
	bool reported;
	int hitCount;

	// Use this for initialization
	void Start () {
		GameObject levelControllerObj = GameObject.Find("LevelController");
		if (levelControllerObj != null) {
			levelController = levelControllerObj.GetComponent<LevelController>();
		}
	
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");

		hitPlayer1 = hitPlayer2 = hitPlayer3 = false;
		reported = false;
		hitCount = 0;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!hitPlayer1 && other.gameObject == player1) {
			hitPlayer1 = true;
			++hitCount;
		}

		if (!hitPlayer2 && other.gameObject == player2) {
			hitPlayer2 = true;
			++hitCount;
		}

		if (!hitPlayer3 && other.gameObject == player3) {
			hitPlayer3 = true;
			++hitCount;
		}

		if (!reported && hitCount >= 2) {
			reported = true;

			if (levelController != null) {
				if (good) {
					levelController.OnWin(3.0f);
				} else {
					levelController.OnLose(3.0f);
				}
			}
		}
	}
}
