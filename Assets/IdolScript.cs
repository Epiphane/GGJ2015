using UnityEngine;
using System.Collections;

public class IdolScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		Debug.Log ("Entered yo");
		//Debug.Log ("Collided with dude like " + col.gameObject.tag);
		SpringJoint myJoint = GetComponent<SpringJoint>();
	//	if (col.collider.tag == "Player") {
	//		myJoint.connectedBody = col.collider.GetComponent<Rigidbody>();
		//}
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log ("Collider time");
	}
}
