using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public RectTransform _panel;
	private bool inpause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			inpause = !inpause;
			if (inpause) {
				Time.timeScale = 0;
				_panel.localPosition = Vector3.zero;

			} else {
				Time.timeScale = 1;
				_panel.localPosition = new Vector3 (-999, -999, -999);
			}
			
		}
	}
	public void resumegame(){
		inpause = false;

		Time.timeScale = 1;
		_panel.localPosition = new Vector3 (-999, -999, -999);
		
	}

	public void quitgame(){
		Application.Quit ();
	}
}
