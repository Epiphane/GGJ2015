using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private string levelToLoad = null;
	private float loadRequestTime = 0.0f;
	private float loadDelay = 0.0f;

	private int sabateur, p1, p2, p3;

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

		sabateur = 1;
		p1 = 2;
		p2 = 3;
		p3 = 4;
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

	public void PickSabateur() {
		sabateur = (int)Random.Range(1.0f, 5.0f);
		p1 = (sabateur <= 1 ? 2 : 1);
		p2 = (sabateur <= 2 ? 3 : 2);
		p3 = (sabateur <= 3 ? 4 : 3);
	}

	public int GetPlayerOne() {
		return p1;
	}

	public int GetPlayerTwo() {
		return p2;
	}

	public int GetPlayerThree() {
		return p3;
	}

	public int GetSabateur() {
		return sabateur;
	}
}
