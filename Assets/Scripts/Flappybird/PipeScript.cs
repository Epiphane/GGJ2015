using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {
	private const float LIFE_TIME = 10.0f;

	private GameObject bird1, bird2, bird3;
	private FlappyScript bird1Script, bird2Script, bird3Script;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		bird1 = GameObject.Find("Flappybird1");
		bird2 = GameObject.Find("Flappybird2");
		bird3 = GameObject.Find("Flappybird3");

		bird1Script = bird1.GetComponent<FlappyScript>();
		bird2Script = bird2.GetComponent<FlappyScript>();
		bird3Script = bird3.GetComponent<FlappyScript>();
	}

	void Update() {
		if (Time.time - startTime > LIFE_TIME) {
			DestroyObject(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == bird1) {
			bird1Script.OnHitPipe();
		}
		if (other.gameObject == bird2) {
			bird2Script.OnHitPipe();
		}
		if (other.gameObject == bird3) {
			bird3Script.OnHitPipe();
		}
	}
}
