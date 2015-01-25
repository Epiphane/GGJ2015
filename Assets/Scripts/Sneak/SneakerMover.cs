using UnityEngine;
using System.Collections;

public class SneakerMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GlobalInput.Meh(); // we'll do it live
	}

	public int player;
	private const float MOVE_SPEED = 5;

	// Update is called once per frame
	void Update () {
		float moveHorizontal =  GlobalInput.players[player].XAxis();
		float moveVertical =   -GlobalInput.players[player].YAxis();
		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
		transform.Translate(translate);
	}
}
