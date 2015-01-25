using UnityEngine;
using System.Collections;

public class FlappyLogicScript : MonoBehaviour {

	private const float PIPE_Y_RANGE = 3.0f;

	public float numSeconds;
	public float interval;

	private FlappyScript bird1Script, bird2Script, bird3Script;
	private int score;
	private bool reported;
	private float initTime;
	private float lastCreate;

	// Use this for initialization
	void Start () {
		bird1Script = GameObject.Find("Flappybird1").GetComponent<FlappyScript>();
		bird2Script = GameObject.Find("Flappybird2").GetComponent<FlappyScript>();
		bird3Script = GameObject.Find("Flappybird3").GetComponent<FlappyScript>();

		score = 0;
		reported = false;
		lastCreate = Time.time;
		initTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!reported && Time.time - initTime >= numSeconds) {
			reported = true;

			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelControllerObj.GetComponent<LevelController>().OnWin(3.0f);
			}
		}

		if (Time.time - lastCreate >= interval) {
			lastCreate = Time.time;

			GameObject pipe = Instantiate(Resources.Load("Flappybird/Pipe")) as GameObject;
			Vector3 pos = pipe.transform.position;
			pos.x = 15.0f;
			pos.y = Random.Range(-PIPE_Y_RANGE, PIPE_Y_RANGE);
			pipe.transform.position = pos;
		}

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
