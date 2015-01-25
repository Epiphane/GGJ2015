using UnityEngine;
using System.Collections;

public class LogicScript : MonoBehaviour {

	private const float WIND_STRENGTH = 1.0f;
	private const float PLAYER_STRENGTH = 1.2f;
	private const float GRAVITY_SCALE = 0.05f;

	private GameObject player1, player2, player3;
	CountdownScript countdownScript;
	bool started;

	int sab, p1, p2, p3;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");
		player1.rigidbody2D.gravityScale = player2.rigidbody2D.gravityScale = player3.rigidbody2D.gravityScale = 0;
		countdownScript = GameObject.Find("Countdown").GetComponent<CountdownScript>();
		started = false;

		sab = GameController.instance.GetSabateur();
		p1 = GameController.instance.GetPlayerOne();
		p2 = GameController.instance.GetPlayerTwo();
		p3 = GameController.instance.GetPlayerThree();
	}
	
	// Update is called once per frame
	void Update () {
		if (!started && countdownScript.Done ()) {
			started = true;
			player1.rigidbody2D.gravityScale = player2.rigidbody2D.gravityScale = player3.rigidbody2D.gravityScale = GRAVITY_SCALE;
		}

		if (!started) {
			return;
		}
	
		float sabateurX = GlobalInput.players[sab].XAxis() * WIND_STRENGTH;
		Vector2 wind = new Vector2(sabateurX, 0.0f);

		float player1X = GlobalInput.players[p1].XAxis() * PLAYER_STRENGTH;
		Vector2 player1Force = new Vector2(player1X, 0.0f);

		float player2X = GlobalInput.players[p2].XAxis() * PLAYER_STRENGTH;
		Vector2 player2Force = new Vector2(player2X, 0.0f);

		float player3X = GlobalInput.players[p3].XAxis() * PLAYER_STRENGTH;
		Vector2 player3Force = new Vector2(player3X, 0.0f);

		player1.rigidbody2D.AddForce(wind + player1Force);
		player2.rigidbody2D.AddForce(wind + player2Force);
		player3.rigidbody2D.AddForce(wind + player3Force);
	}
}
