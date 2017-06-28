using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
	bool isPaused;				//Variable para saber si el juego esta pausado
	public RectTransform _Panel;
	public PlayerMovement _playerMovement;
	// Use this for initialization
	void Start () {
		//Al iniciar el panel debe estar fuera de la pantalla
		_Panel.localPosition = Vector3.one * 999;
	}
	
	// Update is called once per frame
	void Update () {		
		//Detectamos la tecla Escape
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Cambiamos la variable por su valor opuesto
			isPaused = !isPaused;
			if (isPaused) {
				//Si es True, el tiempo se detiene
				Time.timeScale = 0;
				//Y mostramos el Panel, hay dos formas
				//_Panel.anchoredPosition = new Vector2 (0, 0);
				_Panel.localPosition = Vector3.zero;
				_playerMovement.canAttack = false;
			} else {
				//Si es False, el tiempo regresa
				Time.timeScale = 1;
				//Luego sacamos el panel de la pantalla
				_Panel.localPosition = Vector3.one * 999;
				_playerMovement.canAttack = true;
			}
		}
	}

	public void ResumeGame(){
		//Cambiamos la variable por su valor opuesto
		isPaused = !isPaused;
		//Si es False, el tiempo regresa
		Time.timeScale = 1;
		//Luego sacamos el panel de la pantalla
		_Panel.localPosition = Vector3.one * 999;
		_playerMovement.canAttack = true;
	}

	public void QuitGame(){
		//Para salir del juego (solo funciona cuando ha sido compilado, no funciona en las pruebas con Unity)
		Application.Quit ();
	}
	public void RestartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}