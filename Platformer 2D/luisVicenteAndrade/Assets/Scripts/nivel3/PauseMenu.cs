using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public RectTransform _panel ;
	bool Pausa = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode .Escape)) {
			Pausa = !Pausa;
			if (Pausa) {
				Time.timeScale = 0;
				_panel.localPosition = Vector3.zero;

			} else {
				Time.timeScale = 1;
				_panel.localPosition = new Vector3 (-999,-999,-999);
			}

		}
	}
	public void ResumeGame (){
		Pausa = false;
		Time.timeScale = 1;
		_panel.localPosition = new Vector3 (-999,-999,-999);
	}
	public void QuitGame (){
		Application.Quit();
	}
}
