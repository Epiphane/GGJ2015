using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private const float MOVE_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
	
	}

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	// Update is called once per frame
	void Update () {
//		float moveHorizontal = Input.GetAxis("Horizontal");
//		float moveVertical = Input.GetAxis("Vertical");
//		Vector3 translate = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime * MOVE_SPEED;
//		transform.Translate(translate);


		if (Input.GetKey ("joystick 1 button 0")) {
			Debug.Log ("joystick 1 button 0");
		}

		if (Input.GetKey ("joystick 2 button 0")) {
			Debug.Log ("joystick 2 button 0");
		}

		if (Input.GetKey (up))
		{
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.up * Time.deltaTime * 100, transform.localPosition);
		}
		if (Input.GetKey (down))
		{    
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.down * Time.deltaTime * 100, transform.localPosition);
		}  
		if (Input.GetKey (right))
		{
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.right * Time.deltaTime * 100, transform.localPosition);
		}
		if (Input.GetKey (left))
		{    
			transform.parent.gameObject.rigidbody2D.AddForceAtPosition(Vector3.left * Time.deltaTime * 100, transform.localPosition);
		}  
	}
}
