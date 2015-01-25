using UnityEngine;
using System.Collections;

namespace Slots {

	public class SlotScript : MonoBehaviour {

		int[] isSpinning = new int[]{0, 0, 0, 0};
		LevelController levelController;
		private GameObject blocker;
		private int score = 0;

		// Use this for initialization
		// Keep track of results
		void Start () {
			GlobalInput.MehKeyboard();
			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}

			Destroy(GameObject.Find("Options_"+levelController.saboteur));
			isSpinning[levelController.saboteur - 1] = 1;

		// Initialize Blockers to invisible
		for (int i = 1; i<5; i++) {
				GameObject b = GameObject.Find("Options_"+i).transform.Find("Blocker").gameObject;
			if (b) {
				b.SetActive(false);
			}
		}

		}
	
		// Update is called once per frame
		// Computation done here each frame
		void Update () {
			// Count to see if all spinners have stopped
			int count = 0;

			// Check to see if players have hit their button
			for (int i=1; i<5; i++) {
				// Look for SA
				if (GlobalInput.players[levelController.saboteur].ABtn()) {
					int blocked_player = levelController.saboteur;
					while(blocked_player == levelController.saboteur) {
						blocked_player = (int)Random.Range(1,5);
					}

					if (blocker) {
						blocker.SetActive(false);
					}

					// Block the players view for 3s
					blocker = GameObject.Find("Options_"+blocked_player).transform.Find("Blocker").gameObject;
					blocker.SetActive(true);


				}
				// Look for players
				else if (GlobalInput.players[i].ABtn() && isSpinning[i-1] == 0) {
					Debug.Log("Player "+i+" Pressed a Button");
					isSpinning[i-1] = 1;
					// Get actual object being animated
					GameObject spinner = GameObject.Find("Options_"+i);
					// Stop animation kind of
					Animator anim = spinner.GetComponent<Animator>();
					if (anim.GetCurrentAnimatorStateInfo(0).IsName("6_to_7")) {
						anim.SetInteger("stopped", 7);
						score += 1;
					} else {
						anim.SetInteger("stopped", 6);
					}
				}
				count += isSpinning[i-1];

				if (count == 4) {
					if (score >= 2) {
						//WIN
						levelController.OnWin(3.0f);
					}
					else {
						//LOSE
						levelController.OnLose(3.0f);
					}
				}
			}
		}
	}
}
