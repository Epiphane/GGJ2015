using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject title;

	public void LoadLevel(string name) {
		GameController.instance.LoadLevel(name);
	}

	public void Start() {
		title.GetComponent<Animator>().SetTrigger("hi");
	}
}
