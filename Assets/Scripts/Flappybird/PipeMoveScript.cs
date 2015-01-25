using UnityEngine;
using System.Collections;

public class PipeMoveScript : MonoBehaviour {

	private const float SPEED = 4.0f;
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3(-1.0f * SPEED * Time.deltaTime, 0.0f, 0.0f);
	}
}
