using UnityEngine;
using System.Collections;

namespace level2 {

	public class PlayerScript : MonoBehaviour {

		public int player = 1;
		public string action = "Fire1";
		private bool released = true;

		// Use this for initialization
		void Start () {
		}

		public void setExtended(bool extend) {
			Animator anim = gameObject.GetComponent<Animator> ();
			anim.SetBool ("Extended", extend);
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetAxis (action) > 0) {
				if(released) {
					GameObject levelControllerObj = GameObject.Find("LevelController");
					if (levelControllerObj != null) {
						GameScript gameScript = levelControllerObj.GetComponent<GameScript>();
						if (gameScript != null) {
							gameScript.chopTree(player);
						}
					}

					released = false;
				}
			} else {
				released = true;
			}
		}
	}
}
