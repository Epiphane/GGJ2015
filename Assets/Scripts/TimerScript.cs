using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public float levelTime;
	public bool winOnTimeout;

	float startTime;
	Text text;
	LevelController levelController;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		text = GetComponent<Text>();

		GameObject levelControllerObj = GameObject.Find("LevelController");
		if (levelControllerObj != null) {
			levelController = levelControllerObj.GetComponent<LevelController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (levelController != null && levelController.GetState() != LevelController.State.NONE) {
			return;
		}

		float remaining = Mathf.Max(levelTime - (Time.time - startTime), 0.0f);

		if (text) {
			text.text = "Time Left: " + remaining.ToString("#0.00");
		}

		if (remaining <= 0.0f && levelController != null) {
			if (winOnTimeout) {
				levelController.OnWin(3.0f);
			} else {
				levelController.OnLose(3.0f);
			}
		}
	}
}
