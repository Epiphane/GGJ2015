using UnityEngine;
using System.Collections;

namespace ExciteBike {
	public class ObstacleScript : MonoBehaviour {

		public Vector3 velocity = new Vector3(-3.3f, 0, 0);

		// Use this for initialization
		void Start () {
			velocity = new Vector3(-3.3f, 0, 0);
		}

		void FixedUpdate () {
			transform.Translate (velocity * Time.deltaTime);

			if (transform.position.x < -13)
				Destroy (gameObject);
		}
	}
}