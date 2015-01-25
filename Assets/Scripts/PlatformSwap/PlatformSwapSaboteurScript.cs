using UnityEngine;
using System.Collections;

public class PlatformSwapSaboteurScript : MonoBehaviour {

	CountdownScript countdownScript;

	// Use this for initialization
	void Start () {
		countdownScript = GameObject.Find("Countdown").GetComponent<CountdownScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!countdownScript.Done()) {
			return;
		}

		if (GlobalInput.players[4].ABtn()) {
			GameObject[] objects = GameObject.FindGameObjectsWithTag("swapPlatform");
			for (int i = 0; i < objects.Length; ++i) {
				objects[i].GetComponent<PlatformSwapPlatformScript>().swap();
			}
		}
	}
}
