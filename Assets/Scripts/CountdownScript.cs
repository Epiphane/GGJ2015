using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownScript : MonoBehaviour {

	public float timePerNumber;
	
	private float startTime;
	private bool done, hidden;
	private int num;
	private Text text;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		done = false;
		hidden = false;
		num = 3;
		text = GetComponent<Text>();
		text.text = num.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (hidden) {
			return;
		}

		float now = Time.time;
		if (num == 3 && now - startTime >= timePerNumber) {
			num = 2;
			text.text = num.ToString();
			return;
		}
		if (num == 2 && now - startTime >= timePerNumber * 2) {
			num = 1;
			text.text = num.ToString();
			return;
		}
		if (num == 1 && now - startTime >= timePerNumber * 3) {
			num = 0;
			text.text = "Go!";

			done = true;

			return;
		}
		if (num == 0 && now - startTime >= timePerNumber * 4) {
			num = -1;
			text.text = "";
			hidden = true;
			return;
		}
	}

	public bool Done() {
		return done;
	}
}
