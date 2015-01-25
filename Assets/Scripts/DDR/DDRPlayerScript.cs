using UnityEngine;
using System.Collections;

namespace DDR {
	public class DDRPlayerScript : MonoBehaviour {

		public int player = 1;
		LevelController levelController;
		DDRLogic logicController;
		public AudioSource soundEffect;
		bool press;

		// Use this for initialization
		void Start () {
			GlobalInput.MehKeyboard ();

			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}
			
			GameObject logicControllerObj = GameObject.Find("Logic");
			if (logicControllerObj != null) {
				logicController = logicControllerObj.GetComponent<DDRLogic>();
			}
		}
		
		// Update is called once per frame
		void Update () {
			if (GlobalInput.players [player].ABtn ()) {
				if(!press) {
					press = true;
					if(levelController.saboteur == player) {
						logicController.linear = !logicController.linear;
					}
					else {
						if(logicController.strum(player)) {
							soundEffect.Play();
						}
					}
				}
			}
			else
				press = false;
		}
	}
}