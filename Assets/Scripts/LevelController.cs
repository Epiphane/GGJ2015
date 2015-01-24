using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private bool win;

	public string nextLevel;

	// Use this for initialization
	void Start () {
		win = false;
	}

	public void OnWin(float delay) {
		win = true;
		GameController.instance.LoadLevel(nextLevel, delay);
	}

	public void OnLose(float delay) {
		if (win) {
			return;
		}

		GameController.instance.ResetGame(delay);
	}
}
