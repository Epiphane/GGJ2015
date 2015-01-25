using UnityEngine;
using System.Collections;

public class PlatformSwapPlatformScript : MonoBehaviour {

	private bool enabled;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		enabled = Random.value > 0.5f;
		swap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void swap() {
		enabled = !enabled;

		Color color = spriteRenderer.color;
		color.a = enabled ? 1.0f : 0.5f;
		spriteRenderer.color = color;

		collider2D.isTrigger = !enabled;
	}
}
