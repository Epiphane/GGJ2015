using UnityEngine;
using System.Collections;

namespace DDR {
	public class DDRLogic : MonoBehaviour {

		public int BPM = 120;

		LevelController levelController;
		int[] errors = new int[] { 0, 0, 0, 0 };

		public int max_errors = 2;
		private int losers = 0;
		public float space_between_errors = 0.75f;

		public Transform[] finish;

		// Music stuff
		public float startX = 14;
		public GameObject note;
		public ArrayList[] notes = new ArrayList[] { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };
		public int beatsPerNote = 6;
		private float secPerBeat;
		public float timeLeft = -0.4f;

		// UI stuff
		public GameObject error;
		public GameObject instructions;
		public bool linear = true;

		// Use this for initialization
		void Start () {
			secPerBeat = 60.0f / BPM;

			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}

			GameObject playerObj = GameObject.Find ("Player" + GameController.instance.GetSabateur());
			Instantiate(instructions, new Vector3(-3, playerObj.transform.position.y + 0.6f, 1), playerObj.transform.rotation);
		}
		
		// Update is called once per frame
		void Update () {
			// Create notes!
			if (Time.time - timeLeft >= secPerBeat) {
				for(int i = 0; i < 4; i ++) {
					if(i + 1 == GameController.instance.GetSabateur())
						continue;

					if(Random.Range(0, 2) >= 1 && errors [i] <= max_errors) { 
						GameObject newObj = (GameObject) Instantiate (note, 
						                                              new Vector3(startX, finish[i].transform.position.y, -1),
						                                              note.transform.rotation);
						NoteScript newScript = newObj.GetComponent<NoteScript> ();

						newScript.timeLeft = beatsPerNote * secPerBeat;
						newScript.player = i;
						newScript.finish = finish[i];
						notes[i].Add(newScript);
					}
				}

				timeLeft = Time.time;
			}
		}

		public bool strum(int player) {
			player --;

			if (notes [player].Count == 0) {
				addError (player);
				return false;
			} else {
				// Find note that's close to being hittable
				NoteScript noteScript = notes [player][0] as NoteScript;

				if(noteScript.timeLeft <= 0.25f) {
					notes [player].RemoveAt (0);
					Destroy (noteScript.gameObject);

					// Play sound?
					return true;
				}
				else {
					addError (player);
					return false;
				}
			}
		}

		public void missNote(int player) {
			NoteScript note = notes [player] [0] as NoteScript;
			notes [player].RemoveAt (0);
			Destroy (note.gameObject);

			addError (player);
		}

		public void addError(int player) {
			errors [player]++;
			int err = errors [player];

			if (err > max_errors) {
				losers ++;
				while(notes[player].Count > 0) {
					NoteScript note = notes [player] [0] as NoteScript;
					notes [player].RemoveAt (0);
					Destroy (note.gameObject);
				}
				
				if(losers > 2)
					levelController.OnLose (3.0f);
			} else {
				Instantiate(error, finish[player].position +
				            new Vector3(space_between_errors * err, 0, 0), finish[player].rotation);
			}
		}
	}
}