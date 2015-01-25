using UnityEngine;
using System.Collections;

namespace ExciteBike {
	public class PlayerScript : MonoBehaviour {

		public int player = 1;
		public float speed = 4;

		public const float jumpTime = 1.2f;
		public float jumpSpeed = 2;
		private float jumpTimeLeft = 0;

		LevelController levelController;
		ExciteLogicScript logicController;
		Animator animationController;

		// Use this for initialization
		void Start () {
			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}
			
			GameObject logicControllerObj = GameObject.Find("ExciteLogic");
			if (logicControllerObj != null) {
				logicController = logicControllerObj.GetComponent<ExciteLogicScript>();
			}

			animationController = gameObject.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (GlobalInput.players [player].ABtn () &&
			    animationController.GetCurrentAnimatorStateInfo(0).IsTag("Normal")) {
				animationController.SetTrigger("Jump");

				jumpTimeLeft = jumpTime;
			}
		}

		void FixedUpdate () {
			transform.Translate(new Vector3(GlobalInput.players [player].XAxis () * speed * Time.deltaTime,
			                                GlobalInput.players [player].YAxis () * speed * Time.deltaTime, 0));

			if (jumpTimeLeft > 0) {
				float ymove = (jumpTimeLeft * 2 < jumpTime) ? -jumpSpeed : jumpSpeed;
				transform.Translate(new Vector3(0, ymove * Time.deltaTime, ymove * Time.deltaTime));
				jumpTimeLeft -= Time.deltaTime;
			}
		
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);
		}
	}
}