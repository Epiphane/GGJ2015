using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlappyCountdownScript : MonoBehaviour {
	
	private float startTime;
	private bool done;
	private int num;
	private Text text;

	private FlappyScript bird1Script, bird2Script, bird3Script, saboteurScript;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		done = false;
		num = 3;
		text = GetComponent<Text>();
		text.text = num.ToString();

		bird1Script = GameObject.Find("Flappybird1").GetComponent<FlappyScript>();
		bird2Script = GameObject.Find("Flappybird2").GetComponent<FlappyScript>();
		bird3Script = GameObject.Find("Flappybird3").GetComponent<FlappyScript>();
		saboteurScript = GameObject.Find("SaboteurBird").GetComponent<FlappyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (done) {
			return;
		}

		const float SHOW_TIME = 0.75f;

		float now = Time.time;
		if (num == 3 && now - startTime >= SHOW_TIME) {
			num = 2;
			text.text = num.ToString();
			return;
		}
		if (num == 2 && now - startTime >= SHOW_TIME * 2) {
			num = 1;
			text.text = num.ToString();
			return;
		}
		if (num == 1 && now - startTime >= SHOW_TIME * 3) {
			num = 0;
			text.text = "Go!";

			bird1Script.Unfreeze();
			bird2Script.Unfreeze();
			bird3Script.Unfreeze();
			saboteurScript.Unfreeze();

			return;
		}
		if (num == 0 && now - startTime >= SHOW_TIME * 4) {
			num = -1;
			text.text = "";
			done = true;
			return;
		}
	}
}
