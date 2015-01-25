using UnityEngine;
using System.Collections;

public class RoombaGuardMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		playas = new GameObject[] { player1, player2, player3, player4 };
	}

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	private GameObject[] playas;

	public GameObject myLight;

	private int GUARD_FOV = 52;
	private int GUARD_RANGE = 4;
	private int GUARD_TURN_SPEED = 20;

	private float GUARD_SPEED = 1;
	private float GUARD_CHASE_SPEED = 2.5f;

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		myLight.GetComponent<Light>().color = Color.white;

		GameObject target = null;
		float smallestDistance = 9999999999;

		foreach (GameObject player in playas) {
			if(Vector3.Angle(player.transform.position - transform.position, -transform.up) <= GUARD_FOV && Vector3.Distance(transform.position, player.transform.position) < GUARD_RANGE) {
				if(Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, GUARD_RANGE))
				{

					if(hit.transform == player.transform)
					{
						myLight.GetComponent<Light>().color = Color.red;
						if (hit.distance < smallestDistance) {
							target = player;
							smallestDistance = hit.distance;
						}
					}
				}
			}
		}

		if (target != null) {
			var newRotation = Quaternion.LookRotation(transform.position - target.transform.position, -Vector3.forward);
			newRotation.x = 0.0f;
			newRotation.y = 0.0f;
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * GUARD_TURN_SPEED);

			transform.Translate(-Vector3.up * Time.deltaTime * GUARD_CHASE_SPEED);
		}
		else {
			transform.Translate(-Vector3.up * Time.deltaTime * GUARD_SPEED);
		}
	}

	void OnCollisionEnter(Collision col) {
		var newRotation = transform.rotation;
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		newRotation.z += 0.1f;
		transform.rotation = newRotation;
	}
}
