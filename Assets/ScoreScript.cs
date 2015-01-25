using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public static ScoreScript instance;

	public int p1score;
	public int p2score;
	public int p3score;
	public int p4score;

	public int pending1score = 0;
	public int pending2score = 0;
	public int pending3score = 0;
	public int pending4score = 0;

	public void AddScore(int player, int score) {
		if (player == 1) {
			pending1score = score;
		}

		if (player == 2) {
			pending2score = score;
		}

		if (player == 3) {
			pending3score = score;
		}

		if (player == 4) {
			pending4score = score;
		}
	}

	public void ApplyScore() {
		if (pending1score != 0) {
			GameObject.Find("addedPts1").GetComponent<Text>().text = "+" + pending1score;
		}

		if (pending2score != 0) {
			GameObject.Find("addedPts2").GetComponent<Text>().text = "+" + pending2score;
		}

		if (pending3score != 0) {
			GameObject.Find("addedPts3").GetComponent<Text>().text = "+" + pending3score;
		}

		if (pending4score != 0) {
			GameObject.Find("addedPts4").GetComponent<Text>().text = "+" + pending4score;
		}

		p1score += pending1score;
		p2score += pending2score;
		p3score += pending3score;
		p4score += pending4score;

		GameObject.Find("score1text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p1score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score2text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p2score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score3text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p3score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score4text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p4score + "/ 50 POINTS, SCRUB!";

		coolTime = 0;
	}

	// Use this for initialization
	void Start () {
		
	}

	private float coolTime = 0;
	// Update is called once per frame
	void Update () {
		foreach (Player guy in GlobalInput.players) {
			if (guy.ABtn()) {
				Debug.Log ("OK go do the next thing or whatever");
			}
		}
	}
}
