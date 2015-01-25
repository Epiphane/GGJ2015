using UnityEngine;
using System.Collections;

public class PipeMiddleScript : MonoBehaviour {

	private FlappyLogicScript logicScript;
	private bool cleared;

	private GameObject bird1, bird2, bird3;
	private FlappyScript bird1Script, bird2Script, bird3Script;

	// Use this for initialization
	void Start () {
		logicScript = GameObject.Find("FlappyLogic").GetComponent<FlappyLogicScript>();
		cleared = false;

		bird1 = GameObject.Find("Flappybird1");
		bird2 = GameObject.Find("Flappybird2");
		bird3 = GameObject.Find("Flappybird3");
		
		bird1Script = bird1.GetComponent<FlappyScript>();
		bird2Script = bird2.GetComponent<FlappyScript>();
		bird3Script = bird3.GetComponent<FlappyScript>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (cleared) {
			return;
		}
	
		if (other.gameObject == bird1 && bird1Script.IsAlive()) {
			cleared = true;
			logicScript.onClearPipe();
		}
		if (other.gameObject == bird2 && bird2Script.IsAlive()) {
			cleared = true;
			logicScript.onClearPipe();
		}
		if (other.gameObject == bird3 && bird3Script.IsAlive()) {
			cleared = true;
			logicScript.onClearPipe();
		}
	}
}
