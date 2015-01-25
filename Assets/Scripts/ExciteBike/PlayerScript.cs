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

		public Transform playerBike;
		BoxCollider2D playerCollider;

		public bool dead = false;

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

			animationController = playerBike.gameObject.GetComponent<Animator> ();
			playerCollider = GetComponent<BoxCollider2D> ();
		}

		// Update is called once per frame
		void Update () {
			if (dead)
				return;

			if (GlobalInput.players [player].ABtn () &&
			    animationController.GetCurrentAnimatorStateInfo(0).IsTag("Normal")) {
				animationController.SetTrigger("Jump");

				jumpTimeLeft = jumpTime;

				playerCollider.isTrigger = true;
			}

			if (jumpTimeLeft <= 0) {
				playerCollider.isTrigger = false;
			}
		}

		void FixedUpdate () {
			if (dead)
				return;

			transform.Translate(new Vector3(GlobalInput.players [player].XAxis () * speed * Time.deltaTime,
			                                GlobalInput.players [player].YAxis () * speed * Time.deltaTime, 0));

			if (jumpTimeLeft > 0) {
				float ymove = (jumpTimeLeft * 2 < jumpTime) ? -jumpSpeed : jumpSpeed;
				playerBike.Translate (new Vector3 (0, ymove * Time.deltaTime, 0));
				jumpTimeLeft -= Time.deltaTime;
			}
		
			transform.position = new Vector3 (transform.position.x, transform.position.y, playerBike.position.y);
			if (jumpTimeLeft <= 0) {
				playerBike.position = new Vector3 (0, 0.7f, -0.2f) + transform.position;
			}
		}
		
		void OnCollisionEnter2D(Collision2D col) {
			if (player == levelController.saboteur)
				return;

			if (col.gameObject.tag == "bad") {
				logicController.killPlayer(player);
				animationController.SetBool("Die", true);
				dead = true;
			}
		}
	}
}