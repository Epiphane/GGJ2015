using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TheReveal {
	public class RevealLogic : MonoBehaviour {
		
		public float TOTAL_TIME = 5.0f;
		
		float startTime;
		Text text;
		LevelController levelController;
		public int errorsAllowed = 2;
		
		private int[] votes;
		private bool[] moving;
		
		// Use this for initialization
		void Start () {
			votes = new int[] { 0, 1, 2, 3 };
			moving = new bool[] { false, false, false, false };

			startTime = Time.time;
			text = GetComponent<Text>();
			
			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}
		}
		
		// Update is called once per frame
		void Update () {
			UpdatePlayer (0);
			UpdatePlayer (1);
			UpdatePlayer (2);
			UpdatePlayer (3);

			if (levelController != null && levelController.GetState() != LevelController.State.NONE) {
				return;
			}
			
			float remaining = Mathf.Max(TOTAL_TIME - (Time.time - startTime), 0.0f);
			
			if (text) {
				text.text = "Time Left: " + remaining.ToString("#0.00");
 			}
			
			if (remaining <= 0.0f && levelController != null) {
				GameObject option = GameObject.Find("Option" + levelController.saboteur.ToString());
				TextMesh mesh = option.transform.Find("Player").GetComponent<TextMesh>();

				int errors = 0;
				for(int i = 0; i < 4; i ++) {
					if(votes[i] + 1 != levelController.saboteur) {
						errors ++;
					}
				}
				if(errors > errorsAllowed) {
					mesh.color = new Color(1, 0, 0);
					levelController.OnLose(3.0f);
				}
				else {
					mesh.color = new Color(0, 1, 0);
					levelController.OnWin(3.0f);
				}
			}
		}

		void UpdatePlayer(int player) {
			float movement = GlobalInput.players[player + 1].YAxis();
			if (Mathf.Abs(movement) <= 0.1) {
				moving [player] = false;
			}
			else if(!moving[player]) {
				if (movement < 0) {
					moving [player] = true;
					votes [player] ++;

					if (votes [player] > 3)
						votes [player] = 3;
				} else {
					moving [player] = true;
					votes [player] --;

					if (votes [player] < 0)
						votes [player] = 0;
				}

				// Move voter
				GameObject voter = GameObject.Find("Player" + (player + 1).ToString ());
				GameObject option = GameObject.Find("Option" + (votes[player] + 1).ToString ());
				if(voter && option) {
					voter.transform.position = new Vector3(voter.transform.position.x,
					                                       option.transform.position.y,
					                                       voter.transform.position.z);
				}
			}
		}
	}
}