using UnityEngine;
using System.Collections;

public class GlobalInput : MonoBehaviour {
	public static Player P1, P2, P3, P4;

	public GameObject anim1, anim2, anim3, anim4;
	public string nextScene;

	public static Player[] players {
		get {
			return new Player[] {null, P1, P2, P3, P4};
		}
	}

	private int playersAccepted = 0;

	void Update() {
		if (Input.GetKey ("space")) {
			// No controllers? no problem!
			P1 = new KeyboardPlayer(KeyCode.Q, KeyCode.Z, KeyCode.Alpha1, KeyCode.Alpha3);
			P2 = new KeyboardPlayer(KeyCode.U, KeyCode.O, KeyCode.Alpha7, KeyCode.Alpha9);
			P3 = new KeyboardPlayer(KeyCode.RightShift, KeyCode.Return, KeyCode.Keypad1, KeyCode.Backslash);
			P4 = new KeyboardPlayer(KeyCode.Keypad4, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8);

			P1.num = "1";
			P2.num = "2";
			P3.num = "3";
			P4.num = "4";
			playersAccepted = 4;
		}

		if (Input.GetKeyDown("joystick 1 button 0")) {
			anim1.GetComponent<Animator>().SetTrigger("P1Entered");
			P1 = new Player();
			P1.num = "1";
			playersAccepted++;
		}

		if (Input.GetKeyDown("joystick 2 button 0")) {
			anim2.GetComponent<Animator>().SetTrigger("P2Entered");
			P2 = new Player();
			P2.num = "2";
			playersAccepted++;
		}

		if (Input.GetKeyDown("joystick 3 button 0")) {
			anim3.GetComponent<Animator>().SetTrigger("P3Entered");
			P3 = new Player();
			P3.num = "3";
			playersAccepted++;
		}

		if (Input.GetKeyDown("joystick 4 button 0")) {
			anim4.GetComponent<Animator>().SetTrigger("P4Entered");
			P4 = new Player();
			P4.num = "4";
			playersAccepted++;
		}

		if (P1 != null && P2 != null && P3 != null && P4 != null) {
			Application.LoadLevel (nextScene);
		}
	}
}

public class Player {
	public float xDirection;
	public float yDirection;

	public string num;

	public virtual float XAxis() {
		return Input.GetAxis("Horizontal" + num);
	}
	
	public virtual float YAxis() {
		return Input.GetAxis("Vertical" + num);
	}

	public virtual bool ABtn() {
		return Input.GetKeyDown ("joystick " + num + " button 0");
	}

	
	public virtual bool BBtn() {
		return Input.GetKeyDown ("joystick " + num + " button 1");
	}
	
	public virtual bool YBtn() {
		return Input.GetKeyDown ("joystick " + num + " button 2");
	}

	public virtual bool XBtn() {
		return Input.GetKeyDown ("joystick " + num + " button 3");
	}
}

public class KeyboardPlayer: Player {
	KeyCode a, b, c, d;
	public KeyboardPlayer(KeyCode a, KeyCode b, KeyCode c, KeyCode d) {
		this.a = a;
		this.b = b;
		this.c = c;
		this.d = d;
	}

	public override float XAxis() { return Input.GetAxis("KHor" + num); }
	public override float YAxis() { return Input.GetAxis("KVer" + num); }

	public override bool ABtn() { return Input.GetKeyDown (a); }
	public override bool BBtn() { return Input.GetKeyDown (b); }
	public override bool YBtn() { return Input.GetKeyDown (c); }
	public override bool XBtn() { return Input.GetKeyDown (d); }
}