using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			DontDestroyOnLoad(this);
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void LoadLevel(string level) {
		Application.LoadLevel(level);
	}
}
