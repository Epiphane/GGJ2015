using UnityEngine;
using System.Collections;

public class SneakerMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GlobalInput.Meh(); // we'll do it live
	}

	public int player;
	private const float MOVE_SPEED = 1.8f;

	private Vector3 moveDir = Vector3.zero;
	// Update is called once per frame
	void Update () {
		CharacterController con = GetComponent<CharacterController>();
		moveDir = new Vector3(GlobalInput.players[player].XAxis(), GlobalInput.players[player].YAxis(), .11f);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= MOVE_SPEED;

		con.Move (moveDir * Time.fixedDeltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit lol) {
		if (lol.gameObject.tag == "Finish") {
			lol.gameObject.GetComponent<SpringJoint>().connectedBody = GetComponent<Rigidbody>();
		}
	}
}
