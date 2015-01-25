using UnityEngine;
using System.Collections;

public class ExciteLogicScript : MonoBehaviour {

	public float lastCreate;
	public float interval = 1.5f;

	public GameObject[] hazards;
	public Transform[] sources;
	
	LevelController levelController;

	public int alive = 3;

	// Use this for initialization
	void Start () {
		GlobalInput.MehKeyboard ();
		
		GameObject levelControllerObj = GameObject.Find("LevelController");
		if (levelControllerObj != null) {
			levelController = levelControllerObj.GetComponent<LevelController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastCreate >= interval) {
			GameObject hazard = Instantiate(hazards[Random.Range(0, hazards.Length)]) as GameObject;

			hazard.transform.position = sources[Random.Range(0, sources.Length)].position;

			lastCreate = Time.time;
//
//			GameObject pipe = Instantiate(Resources.Load("Flappybird/Pipe")) as GameObject;
//			Vector3 pos = pipe.transform.position;
//			pos.x = 15.0f;
//			pos.y = Random.Range(-PIPE_Y_RANGE, PIPE_Y_RANGE);
//			pipe.transform.position = pos;
		}
	}

	public void killPlayer(int player) {
		alive --;

		if (alive == 0) {
			levelController.OnLose(3.0f);
		}
	}
}
