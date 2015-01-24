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

			ShowWin();
			UpdateController();
		}
	}

	void ShowWin() {
		GameObject textObject = GameObject.Find("Win Text");
		if (textObject != null) {
			Text text = textObject.GetComponent<Text>();
			if (text != null) {
				text.text = "Good Job!";
			}
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
