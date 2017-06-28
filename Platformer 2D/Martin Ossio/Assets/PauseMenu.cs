using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public RectTransform _panel;
	private bool inPaused = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			inPaused = !inPaused;

			if (inPaused) {
				PauseGame ();
			} else {
				ResumeGame ();
			}

		}
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		_panel.localPosition = new Vector3 (-999,-999,-999);
		inPaused = false;
	}

	public void PauseGame(){
		Time.timeScale = 0;
		_panel.localPosition = Vector3.zero;
		inPaused = true;

	}


	public void RestartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		ResumeGame ();
	}


	public void QuitGame(){
		Application.Quit ();
	}



}
