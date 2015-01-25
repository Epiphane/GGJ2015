using UnityEngine;
using System.Collections;

public class SwapDoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject.Find("LevelController").GetComponent<LevelController>().OnWin(3.0f);
	}
}
