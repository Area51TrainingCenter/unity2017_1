using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public RectTransform _panel;
	private bool inPause = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			//invertimos el valor del booleano
			inPause = !inPause;
			//si el juego esta en pausa...
			if (inPause) {
				//congelamos el tiempo
				Time.timeScale = 0;
				//localPosition es la posicion del objeto relativo a su padre
				//colocamos el panel de pausa al centro de la pantalla
				_panel.localPosition = Vector3.zero;
			} else {//sino...
				//que el tiempo fluya normal
				Time.timeScale = 1;
				//colocamos el panel de pausa fuera de la pantalla
				_panel.localPosition = new Vector3 (-999, -999, -999);
			}
		}
	}

	public void ResumeGame(){
		//actualizamos el booleano porque el juego ya no esta en pausa
		inPause = false;
		//que el tiempo fluya normal
		Time.timeScale = 1;
		//colocamos el panel de pausa fuera de la pantalla
		_panel.localPosition = new Vector3 (-999, -999, -999);
	}

	public void QuitGame(){
		//esto hace que el juego se cierre (no funciona en el editor solo en el compilado)
		Application.Quit ();
	}
}
