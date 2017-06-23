using System.Collections;
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
		if (Input.GetKeyDown(KeyCode.Escape)) {
			//invierte el valor del booleano
			inPause = !inPause;
			//sim el juego esta en pausa
			if (inPause) {
				//congelamos el tiempo
				Time.timeScale = 0;
				//colocamos el panel en pausa al centro d ela pantalla
				_panel.localPosition = Vector3.zero;
			}else{//sino...
				//que le timepo fluya normal
				Time.timeScale = 1;
				//colocamos el panel de pausa fuera de la pantalla
				_panel.localPosition = new Vector3 (-999, -999, -999);
			}
		}
	}

	public void resumeGame (){
		inPause = false;
		//que le timepo fluya normal
		Time.timeScale = 1;
		//colocamos el panel de pausa fuera de la pantalla
		_panel.localPosition = new Vector3 (-999, -999, -999);
	}

	public void quitGame (){
		//esto hace que el juego se cierre (no funciona en el editor solo en el compilado)
		Application.Quit ();
	}
}
