using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	public enum State {
		WIN,
		LOSE,
		NONE
	}

	private State state = State.NONE;
	private Animator leftEndAnim, rightEndAnim;

	public string nextLevel;

	// Use this for initialization
	void Start () {
		state = State.NONE;
		leftEndAnim = GameObject.Find("LeftEnd").GetComponent<Animator>();
		rightEndAnim = GameObject.Find("RightEnd").GetComponent<Animator>();

		GameController.instance.PickSabateur();
	}

	public State GetState() {
		return state;
	}

	public void OnWin(float delay) {
		if (state != State.NONE) {
			return;
		}
		state = State.WIN;

		EndAnim();
		ShowText("Good Job!", new Color(0.1f, 0.9f, 0.5f));


		for (int i = 1; i < 5; i++) {
			if (i == GameController.instance.GetSabateur()) {
				continue;
			}

			ScoreScript.instance.AddScore(i, 10);
		}
		
		GameController.instance.LoadLevel(nextLevel, delay);
		//ScoreScript.instance.DoLevel(nextLevel, delay);	
	}

	public void OnLose(float delay) {
		if (state != State.NONE) {
			return;
		}
		state = State.WIN;

		EndAnim();
		ShowText("Sabotaged!", new Color(0.8f, 0.1f, 0.2f));
		
		ScoreScript.instance.AddScore(GameController.instance.GetSabateur(), 15);
		ScoreScript.instance.ApplyScore();
		GameController.instance.LoadLevel(nextLevel, delay);
		//ScoreScript.instance.DoLevel(nextLevel, delay);
	}	

	void EndAnim() {
		leftEndAnim.SetTrigger("endgame");
		rightEndAnim.SetTrigger("endgame");
	}
	
	void ShowText(string message, Color color) {
		GameObject canvas = GameObject.Find("Canvas");
		if (canvas == null) {
			return;
		}
	
		GameObject textObject = new GameObject();
		textObject.transform.SetParent(canvas.transform);

		Text text = textObject.AddComponent("Text") as Text;
		text.transform.localPosition = new Vector3(0.0f, -150.0f, 0.0f);

		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.fontSize = 72;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.verticalOverflow = VerticalWrapMode.Overflow;
		text.alignment = TextAnchor.MiddleCenter;

		text.text = message;
		text.color = color;
	}
}
