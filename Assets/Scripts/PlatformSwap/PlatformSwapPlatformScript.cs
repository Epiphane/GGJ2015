using UnityEngine;
using System.Collections;

public class PlatformSwapPlatformScript : MonoBehaviour {

	public bool platformEnabled;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		updateState();
	}

	public void swap() {
		platformEnabled = !platformEnabled;
		updateState();
	}

	private void updateState() {
		Color color = spriteRenderer.color;
		color.a = platformEnabled ? 1.0f : 0.5f;
		spriteRenderer.color = color;
		
		collider2D.isTrigger = !platformEnabled;
	}
}
