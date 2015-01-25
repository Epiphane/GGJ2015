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

	private bool waiting = false;

	public void ApplyScore() {
		if (pending1score != 0) {
			//GameObject.Find("addedPts1").GetComponent<Text>().text = "+" + pending1score;
		}
		
		if (pending2score != 0) {
			//GameObject boo = GameObject.Find ("addedPts2");
			//Text lol = boo.GetComponent<Text>();
			//lol.text = "+" + pending2score;
		}
		
		if (pending3score != 0) {
			//GameObject.Find("addedPts3").GetComponent<Text>().text = "+" + pending3score;
		}
		
		if (pending4score != 0) {
			//GameObject.Find("addedPts4").GetComponent<Text>().text = "+" + pending4score;
		}
		
		p1score += pending1score;
		p2score += pending2score;
		p3score += pending3score;
		p4score += pending4score;
		
		//GameObject.Find("score1text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p1score + "/ 50 POINTS, SCRUB!";
		//GameObject.Find("score2text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p2score + "/ 50 POINTS, SCRUB!";
	//	GameObject.Find("score3text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p3score + "/ 50 POINTS, SCRUB!";
		//GameObject.Find("score4text").GetComponent<Text>().text = "SO FAR YOU'VE GOT \n" + p4score + "/ 50 POINTS, SCRUB!";
		waiting = true;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	public void DoLevel(string nextLevel, float delay) {
		Application.LoadLevel("Score");
		ApplyScore();
		
		if (p1score < 50 && p2score < 50 && p3score < 50 && p4score < 50) {
			GameController.instance.LoadLevel(nextLevel, delay);
		}
		else {
			GameController.instance.LoadLevel("Sluts", 3);
		}
	}
	
	public ArrayList WhoWon() {
		ArrayList result = new ArrayList();
		
		if (p1score >= 50) {
			result.Add(1);
		}
		
		if (p2score >= 50) {
			result.Add(2);
		}
		
		if (p3score >= 50) {
			result.Add(3);
		}
		
		if (p4score >= 50) {
			result.Add(4);
		}
		
		return result;
	}
	
	private float coolTime = 0;
	// Update is called once per frame
	void Update () {
		if (waiting) {
			Debug.Log ("lol waiting");
			if (ScoreUIHandler.currHandler != null) {
				ScoreUIHandler.currHandler.ApplyScore(p1score, p2score, p3score, p4score, pending1score, pending2score, pending3score, pending4score);
				waiting = false;
				Debug.Log ("yey we did it");
			}
		}

		foreach (Player guy in GlobalInput.players) {
			if (guy == null) {
				continue;
			}

			if (guy.ABtn()) {
				Debug.Log ("OK go do the next thing or whatever");
			}
		}
	}
}