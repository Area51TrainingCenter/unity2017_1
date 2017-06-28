using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Para utilizar recursos de Scenas
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public RectTransform panel;
	private bool inPause = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			inPause = !inPause;

			if (inPause) {
				Time.timeScale = 0;
				panel.localPosition = Vector3.zero;
			} else {
				Time.timeScale = 1;
				panel.localPosition = new Vector3(-999,-999,-999);
			}
		}
	}

	public void ResumeGame () {
		inPause = false;
		Time.timeScale = 1;
		panel.localPosition = new Vector3(-999,-999,-999);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void Reestart () {
		// reestablecemos el tiempo
		Time.timeScale = 1;
		// recargamos la escena
		SceneManager.LoadScene (SceneManager.GetActiveScene().name); // SceneManager.GetActiveScene().name, me devuelve la escena actual
	}

}
