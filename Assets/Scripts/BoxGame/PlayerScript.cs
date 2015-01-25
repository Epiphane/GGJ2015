using UnityEngine;
using System.Collections;
//using XInputDotNetPure;

public class PlayerScript : MonoBehaviour {

	private const float MOVE_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
		//GamePad.SetVibration(0, 1, 1);
	}

	public int player;

	// Update is called once per frame
	void Update () {
		float moveHorizontal =  GlobalInput.players[player].XAxis();
		float moveVertical =   -GlobalInput.players[player].YAxis();
		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
		transform.Translate(translate);
	}
}
