using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	private bool inPause;
	public RectTransform _panel;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ResumenGame ();
		}
	}
	public void ResumenGame(){
		//invertimos el valor del booleano
		inPause = !inPause;
		//si el juego está en pausa
		if (inPause) {
			//congelamos el tiempo 
			Time.timeScale = 0;
			//Posición según la posición del padre--localPosition
			_panel.localPosition = Vector3.zero;
		} else {
			//recuperamos el tiempo
			Time.timeScale = 1;
			//lo sacamos fuera de la cámara
			_panel.localPosition = new Vector3 (-999, -999, -999);
		}
	}
	public void QuitGame(){
		//esto hace que el juego se cierre(no funciona en el editor)
		Application.Quit ();
	}
}
