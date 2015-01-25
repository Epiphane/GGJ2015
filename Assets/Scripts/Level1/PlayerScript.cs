using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerScript : MonoBehaviour {

	private const float MOVE_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
		GamePad.SetVibration(0, 1, 1);
	}

	public int player = 1;

	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("p" + player.ToString() + "_Horizontal_keyboard");
		float moveVertical = Input.GetAxis("p" + player.ToString() + "_Vertical_keyboard");
		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
		transform.Translate(translate);
	}
}
