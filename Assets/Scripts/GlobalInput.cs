using UnityEngine;
using System.Collections;

public class GlobalInput : MonoBehaviour {
	public static Player P1, P2, P3, P4;

	public GameObject anim1, anim2, anim3, anim4;

	public static Player[] players {
		get {
			return new Player[] {null, P1, P2, P3, P4};
		}
	}

	void Update() {
		if (Input.GetKeyDown("joystick 1 button 0")) {
			anim1.GetComponent<Animator>().SetTrigger("P1Entered");
			P1 = new Player();
			P1.num = "1";
		}

		if (Input.GetKeyDown("joystick 2 button 0")) {
			anim2.GetComponent<Animator>().SetTrigger("P2Entered");
			P2 = new Player();
			P2.num = "2";
		}

		if (Input.GetKeyDown("joystick 3 button 0")) {
			anim3.GetComponent<Animator>().SetTrigger("P3Entered");
			P3 = new Player();
			P3.num = "3";
		}

		if (Input.GetKeyDown("joystick 4 button 0")) {
			anim4.GetComponent<Animator>().SetTrigger("P4Entered");
			P4 = new Player();
			P4.num = "4";
		}
		
	}
}

public class Player {
	public float xDirection;
	public float yDirection;

	public string num;

	public float XAxis() {
		return Input.GetAxis("Horizontal" + num);
	}
	
	public float YAxis() {
		return Input.GetAxis("Vertical" + num);
	}

	public bool ABtn() {
		return Input.GetKey ("joystick " + num + " button 0");
	}

	
	public bool BBtn() {
		return Input.GetKey ("joystick " + num + " button 1");
	}
	
	public bool YBtn() {
		return Input.GetKey ("joystick " + num + " button 2");
	}

	public bool XBtn() {
		return Input.GetKey ("joystick " + num + " button 3");
	}
}