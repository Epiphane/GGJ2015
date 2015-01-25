using UnityEngine;
using System.Collections;

namespace DDR {
	public class NoteScript : MonoBehaviour {

		public int player;
		public Transform finish;
		public float timeLeft;
		private Vector3 linearVelocity = new Vector3(0, 0, 0);

		private DDRLogic logicController;

		// Use this for initialization
		void Start () {
			GameObject logicObj = GameObject.Find ("Logic");
			if (logicObj) {
				logicController = logicObj.GetComponent<DDRLogic>();
			}

			linearVelocity = new Vector3 (0, 0, 0);
		}
		
		// Update is called once per frame
		void Update () {
		}

		void FixedUpdate() {
			float distance = Vector3.Distance(finish.position, transform.position);

			if(logicController.linear || timeLeft < 0.6f) {
				if(finish.position.x < transform.position.x && distance > 0.3f) {
					linearVelocity.x = -distance / timeLeft;
				}
			}
			// Exponentiallll!!!
			else {
				if(finish.position.x < transform.position.x) {
					linearVelocity.x = -distance / (timeLeft * 2);
				}
			}

			transform.Translate(linearVelocity * Time.deltaTime);
			 
			if(timeLeft < 0.1 && timeLeft > 0) {
				transform.localScale = new Vector3(1.25f, 1.25f, 1);
			} else {
				transform.localScale = new Vector3(1, 1, 1);
			}

			if(timeLeft < -0.1f) {
				logicController.missNote(player);
			}
			
			timeLeft -= Time.deltaTime;
		}
	}
}
