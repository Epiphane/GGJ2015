using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private const float MOVE_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
		transform.Translate(translate);
	}
}
