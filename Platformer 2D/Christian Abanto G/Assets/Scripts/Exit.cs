using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Para utilizar recursos de Scenas
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	private GameObject player;
	private bool meVoy = false;
	private bool touchedTrigger = false;

	//public string TargetTag="Player";  //Definir a quien le va a hacer daño

	/*
	 * obener gameobject player
	 * desactivar script playermovement
	 * activamos estado exit (animator )
	 * 
	*/

	// Use this for initialization
	void Start () {		
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (meVoy) {
			player.transform.Translate(0,Time.deltaTime*15,0);
		}

		if (player.GetComponent<PlayerMovement>().isGrounded && touchedTrigger) {
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; // lo mismo que -> new Vector2(0,0)
			// empezar animacion
			player.GetComponentInChildren<Animator>().SetTrigger ("exit");
			Invoke ("exitUp", 2+1);
			Invoke ("cambiarEscena", 2+2);
			// apagamos el touched Trigger
			touchedTrigger = false;
		} 

	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			// hacemos esto para que el layerya no se pueda mover
			// en horizontal y para permitir que caiga al piso
			player.GetComponent<PlayerMovement> ().canControl = false; // apagamos sus movientos
			touchedTrigger = true;
		}
	}

	void exitUp(){
		meVoy = true;		
		// deshabilitar el script
		GameObject camarita = GameObject.FindGameObjectWithTag("MainCamera");
		camarita.GetComponent<PlayerCamara>().enabled=false;
	}

	void cambiarEscena(){
		// guardar datos en el dispositivo ()
		PlayerPrefs.SetInt("playerScore", GameObject.Find("Score Manager").GetComponent<ScoreManager>().score);
		// cambiamos la escena
		SceneManager.LoadScene ("winScreen");
	}


}
