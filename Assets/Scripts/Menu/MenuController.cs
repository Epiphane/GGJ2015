using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void LoadLevel(string name) {
		GameController.instance.LoadLevel(name);
	}
}
