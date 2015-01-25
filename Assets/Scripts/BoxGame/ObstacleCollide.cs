using UnityEngine;
using System.Collections;

public class ObstacleCollide : MonoBehaviour {
	
	LevelController levelController;

	// Use this for initialization
	void Start () {
		GameObject levelControllerObj = GameObject.Find("LevelController");
		if (levelControllerObj != null) {
			levelController = levelControllerObj.GetComponent<LevelController>();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "bad") {
			levelController.OnLose(3.0f);
		}
		
		if (col.gameObject.tag == "Finish") {
			levelController.OnWin(3.0f);
		}
	}
}
