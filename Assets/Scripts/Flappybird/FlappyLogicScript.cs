using UnityEngine;
using System.Collections;

public class FlappyLogicScript : MonoBehaviour {

	public float numSeconds;

	private FlappyScript bird1Script, bird2Script, bird3Script;
	private int score;
	private bool reported;

	// Use this for initialization
	void Start () {
		bird1Script = GameObject.Find("Flappybird1").GetComponent<FlappyScript>();
		bird2Script = GameObject.Find("Flappybird2").GetComponent<FlappyScript>();
		bird3Script = GameObject.Find("Flappybird3").GetComponent<FlappyScript>();

		score = 0;
		reported = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!reported && !bird1Script.IsAlive() && !bird2Script.IsAlive() && !bird3Script.IsAlive()) {
			reported = true;

			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelControllerObj.GetComponent<LevelController>().OnLose(3.0f);
			}
		}
	}

	public void onClearPipe() {
		++score;
	}
}
