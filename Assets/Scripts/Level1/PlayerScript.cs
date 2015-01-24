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

		if (Input.GetKey (up))
		{
			transform.Translate(Vector3.up * Time.deltaTime *4, Space.World);
		}
		if (Input.GetKey (down))
		{    
			transform.Translate(Vector3.down * Time.deltaTime *4, Space.World);
		}  
		if (Input.GetKey (right))
		{
			transform.Translate(Vector3.right* Time.deltaTime *4, Space.World);
		}
		if (Input.GetKey (left))
		{    
			transform.Translate(Vector3.left* Time.deltaTime *4, Space.World);
		}  
	}
}
