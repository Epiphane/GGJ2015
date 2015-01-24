using UnityEngine;
using System.Collections;

namespace level2 {

	public class GameScript : MonoBehaviour {

		public int treeHealth = 40;
		private int currHealth;
		private int lastPlayer;

		// Use this for initialization
		void Start () {
			currHealth = treeHealth;
			lastPlayer = 1;
		}
		
		// Update is called once per frame
		void Update () {
		}

		public void chopTree(int player) {
			if (player != lastPlayer) {
				lastPlayer = player;
				currHealth --;

				// Change player pictures
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				for (int i = 0; i < players.Length; i ++) {
						level2.PlayerScript playerScript = players [i].GetComponent<level2.PlayerScript> ();
						if (!playerScript) {
								continue;
						}

						if (playerScript.player == player) {
								playerScript.setExtended (true);
						} else {
								playerScript.setExtended (false);
						}
				}

				// Change Saw
				Animator sawAnim = GameObject.Find ("Saw").GetComponent<Animator> ();
				if (sawAnim) {
						sawAnim.SetInteger ("Player", player);
				}

				Animator treeAnim = GameObject.Find ("Tree").GetComponent<Animator> ();
				if (treeAnim) {
						treeAnim.SetInteger ("Health", currHealth * 100 / treeHealth);
				}

				if (currHealth <= 0) { 
						LevelController levelController = gameObject.GetComponent<LevelController> ();
						if (levelController != null) {
								levelController.OnWin (3.0f);
						}
				}
			}
		}
	}
}
