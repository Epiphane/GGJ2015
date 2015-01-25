using UnityEngine;
using System.Collections;

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
			GameObject.Find("addedPts1").guiText = "+" + pending1score;
		}

		if (pending2score != 0) {
			GameObject.Find("addedPts2").guiText = "+" + pending2score;
		}

		if (pending3score != 0) {
			GameObject.Find("addedPts3").guiText = "+" + pending3score;
		}

		if (pending4score != 0) {
			GameObject.Find("addedPts4").guiText = "+" + pending4score;
		}

		p1score += pending1score;
		p2score += pending2score;
		p3score += pending3score;
		p4score += pending4score;

		GameObject.Find("score1text").guiText = "SO FAR YOU'VE GOT \n" + p1score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score2text").guiText = "SO FAR YOU'VE GOT \n" + p2score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score3text").guiText = "SO FAR YOU'VE GOT \n" + p3score + "/ 50 POINTS, SCRUB!";
		GameObject.Find("score4text").guiText = "SO FAR YOU'VE GOT \n" + p4score + "/ 50 POINTS, SCRUB!";

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
