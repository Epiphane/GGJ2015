using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIHandler : MonoBehaviour {

	public static ScoreUIHandler currHandler;

	// Use this for initialization
	void Start () {
		Debug.Log ("Hi score started");
		ScoreUIHandler.currHandler = this;

		int p1 = ScoreScript.instance.p1score;
		int p2 = ScoreScript.instance.p2score;
		int p3 = ScoreScript.instance.p3score;
		int p4 = ScoreScript.instance.p4score;

		Debug.Log ("hey " + p1 + " " + p2 + " " + p3 + " " + p4);
		ApplyScore (p1, p2, p3, p4, 0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void ApplyScore(int p1score, int p2score, int p3score, int p4score, int pending1score, int pending2score, int pending3score, int pending4score) {
		Debug.Log ("HI this i sscore ");
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
		
		GameObject.Find("score1text").GetComponent<Text>().text = "YOU GOT " + p1score + " POINTS, SCRUB!";
		GameObject.Find("score2text").GetComponent<Text>().text = "YOU GOT " + p2score + " POINTS, SCRUB!";
		GameObject.Find("score3text").GetComponent<Text>().text = "YOU GOT " + p3score + " POINTS, SCRUB!";
		GameObject.Find("score4text").GetComponent<Text>().text = "YOU GOT " + p4score + " POINTS, SCRUB!";

	}
}
