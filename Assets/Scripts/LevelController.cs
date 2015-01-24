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

	public string nextLevel;

	// Use this for initialization
	void Start () {
		state = State.NONE;
	}

	public State GetState() {
		return state;
	}

	public void OnWin(float delay) {
		if (state != State.NONE) {
			return;
		}
		state = State.WIN;

		ShowText("Good Job!", new Color(0.1f, 0.9f, 0.5f));

		GameController.instance.LoadLevel(nextLevel, delay);
	}

	public void OnLose(float delay) {
		if (state != State.NONE) {
			return;
		}
		state = State.WIN;

		ShowText("You Suck!", new Color(0.8f, 0.1f, 0.2f));

		GameController.instance.ResetGame(delay);
	}

	void ShowText(string message, Color color) {
		GameObject canvas = GameObject.Find("Canvas");
		if (canvas == null) {
			return;
		}
	
		GameObject textObject = new GameObject();
		textObject.transform.SetParent(canvas.transform);

		Text text = textObject.AddComponent("Text") as Text;
		text.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.fontSize = 72;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.verticalOverflow = VerticalWrapMode.Overflow;
		text.alignment = TextAnchor.MiddleCenter;

		text.text = message;
		text.color = color;
	}
}
