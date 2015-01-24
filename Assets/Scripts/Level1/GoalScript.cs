using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalScript : MonoBehaviour {

	private bool hit;

	// Use this for initialization
	void Start () {
		hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			return;
		}

		GameObject player = GameObject.Find("Player");
		if (player == null) {
			return;
		}

		if (renderer.bounds.Intersects(player.renderer.bounds)) {
			hit = true;

			UpdateController();
		}
	}
	
	void UpdateController() {
		GameObject levelControllerObj = GameObject.Find("LevelController");
		if (levelControllerObj != null) {
			LevelController levelController = levelControllerObj.GetComponent<LevelController>();
			if (levelController != null) {
				levelController.OnWin(3.0f);
			}
		}
	}
}
