﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	private bool inPause;
	public RectTransform _panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			inPause = !inPause;
			if (inPause) {
				Time.timeScale = 0;// congelar
				_panel.localPosition = Vector3.zero;
			} else {
				Time.timeScale = 1;
				_panel.localPosition = new Vector3 (-999,-999,-999);
			}

		}

	}


	public void ResumeGame(){
		inPause = false;
		Time.timeScale = 1;
		_panel.localPosition = new Vector3 (-999,-999,-999);
	}


	public void QuitGame(){
		Application.Quit ();
	}
}
