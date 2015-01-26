using UnityEngine;
using System.Collections;

public class PlatformSwapSaboteurScript : MonoBehaviour {

	const float TIME_BETWEEN = 1.0f;

	CountdownScript countdownScript;
	float lastSwapTime;

	// Use this for initialization
	void Start () {
		countdownScript = GameObject.Find("Countdown").GetComponent<CountdownScript>();
		lastSwapTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!countdownScript.Done()) {
			return;
		}

		if (GlobalInput.players[GameController.instance.GetSabateur()].ABtn() &&
		    Time.time - lastSwapTime >= TIME_BETWEEN) {
			lastSwapTime = Time.time;
			GameObject[] objects = GameObject.FindGameObjectsWithTag("swapPlatform");
			for (int i = 0; i < objects.Length; ++i) {
				objects[i].GetComponent<PlatformSwapPlatformScript>().swap();
			}
		}
	}
}
