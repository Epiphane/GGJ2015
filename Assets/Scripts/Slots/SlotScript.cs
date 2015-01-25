using UnityEngine;
using System.Collections;

namespace Slots {

	public class SlotScript : MonoBehaviour {

		bool[] isSpinning = new bool[]{true, true, true, true};

		// Use this for initialization
		// Keep track of results
		void Start () {
			
		}
	
		// Update is called once per frame
		// Computation done here each frame
		void Update () {
			// Check to see if players have hit their button
			for (int i=1; i<5; i++) {
				// Check to see if A is pressed
				if (GlobalInput.players[i].ABtn() && isSpinning[i-1]) {
					Debug.Log("Player "+i+" Pressed a Button");
					isSpinning[i] = false;
					// Get actual object being animated
					GameObject spinner = GameObject.Find("Options_"+i);
					// Stop animation kind of
					Animator anim = spinner.GetComponent<Animator>();
					if (anim.GetCurrentAnimatorStateInfo(0).IsName("6_to_7")) {
						Debug.Log("Stopping on 7 for player "+i);
						anim.SetInteger("stopped", 7);
					} else {
						Debug.Log("Stopping on 6 for player "+i);
						anim.SetInteger("stopped", 6);
					}
				}
			}
		}
	}
}
