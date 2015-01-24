﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TheReveal {
	public class TimerScript : MonoBehaviour {
		
		const float TOTAL_TIME = 5.0f;
		
		float startTime;
		Text text;
		LevelController levelController;
		
		private int[] votes;
		
		// Use this for initialization
		void Start () {
			votes = new int[] { 1, 2, 3, 4 };

			startTime = Time.time;
			text = GetComponent<Text>();
			
			GameObject levelControllerObj = GameObject.Find("LevelController");
			if (levelControllerObj != null) {
				levelController = levelControllerObj.GetComponent<LevelController>();
			}
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetAxis ("p1_Horizontal_keyboard")) {
			}

			if (levelController != null && levelController.GetState() != LevelController.State.NONE) {
				return;
			}
			
			float remaining = Mathf.Max(TOTAL_TIME - (Time.time - startTime), 0.0f);
			
			if (text) {
				text.text = "Time Left: " + remaining.ToString("#0.00");
			}
			
			if (remaining <= 0.0f && levelController != null) {
				//			levelController.OnLose(3.0f);
			}
		}
	}
}