using UnityEngine;
using System.Collections;

public class LogicScript : MonoBehaviour {

	private const float WIND_STRENGTH = 1.0f;
	private const float PLAYER_STRENGTH = 1.2f;

	private GameObject player1, player2, player3;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");
	}
	
	// Update is called once per frame
	void Update () {
		float sabateurX = Input.GetAxis("p1_Horizontal_keyboard") * WIND_STRENGTH;
		Vector2 wind = new Vector2(sabateurX, 0.0f);

		float player1X = Input.GetAxis("p2_Horizontal_keyboard") * PLAYER_STRENGTH;
		Vector2 player1Force = new Vector2(player1X, 0.0f);

		float player2X = Input.GetAxis("p3_Horizontal_keyboard") * PLAYER_STRENGTH;
		Vector2 player2Force = new Vector2(player2X, 0.0f);

		float player3X = Input.GetAxis("p4_Horizontal_keyboard") * PLAYER_STRENGTH;
		Vector2 player3Force = new Vector2(player3X, 0.0f);

		player1.rigidbody2D.AddForce(wind + player1Force);
		player2.rigidbody2D.AddForce(wind + player2Force);
		player3.rigidbody2D.AddForce(wind + player3Force);
	}
}
