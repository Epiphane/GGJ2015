using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private string levelToLoad = null;
	private float loadRequestTime = 0.0f;
	private float loadDelay = 0.0f;

	void Awake () {
		if (instance == null) {
			DontDestroyOnLoad(this);
			instance = this;
			if (ScoreScript.instance == null) {
				ScoreScript.instance = new ScoreScript();
				DontDestroyOnLoad(ScoreScript.instance);

				ScoreScript.instance.p1score = 0;
				ScoreScript.instance.p2score = 0;
				ScoreScript.instance.p3score = 0;
				ScoreScript.instance.p4score = 0;
			}
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void Update() {
		if (levelToLoad != null && (Time.time - loadRequestTime) >= loadDelay) {
			Application.LoadLevel(levelToLoad);
			levelToLoad = null;
		}
	}

	public void LoadLevel(string level, float delay) {
		if (levelToLoad == null) {
			levelToLoad = level;
			loadRequestTime = Time.time;
			loadDelay = delay;
		}
	}

	public void LoadLevel(string level) {
		LoadLevel(level, 0.0f);
	}

	public void ResetGame(float delay) {
		LoadLevel("Menu", delay);
	}

	public void ResetGame() {
		ResetGame(0.0f);
	}
}
