using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	private bool inPause;
	public RectTransform _panel;
	// Use this for initialization
	void Start () {
		_panel.localPosition = Vector3.one*999;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			inPause = !inPause;

			//si esta en pausa, el juego se congela
			if (inPause) {
				Time.timeScale = 0;
				//local posicion es la posicion del objeto relativo a su padre
				_panel.localPosition = Vector3.zero;
			}
			else  {
				Time.timeScale = 1;
				_panel.localPosition = Vector3.one*999;
			}
		}
	}


	public void resumeGame () {
		inPause = false;
		Time.timeScale = 1;
		_panel.localPosition = Vector3.one*999;
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void Restart () {
		//carga escena actualmente cargada
		Time.timeScale=1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
