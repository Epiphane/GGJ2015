using UnityEngine;
using System.Collections;

public class PlatformSwapSaboteurScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalInput.players[1].ABtn()) {
			GameObject[] objects = GameObject.FindGameObjectsWithTag("swapPlatform");
			for (int i = 0; i < objects.Length; ++i) {
				objects[i].GetComponent<PlatformSwapPlatformScript>().swap();
			}
		}
	}
}
