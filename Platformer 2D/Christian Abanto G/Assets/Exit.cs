using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public GameObject player;
	public bool meVoy;
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
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; // lo mismo que -> new Vector2(0,0)
			// empezar animacion
			player.GetComponentInChildren<Animator>().SetTrigger ("exit");
			Invoke ("exitUp", 1);
			Invoke ("cambiarEscena", 2);
		}
	}

	void exitUp(){
		meVoy = true;		
		// deshabilitar el script
		GameObject camarita = GameObject.FindGameObjectWithTag("MainCamera");
		camarita.GetComponent<PlayerCamara>().enabled=false;
	}

	void cambiarEscena(){
		SceneManager.LoadScene ("winScreen");
	}


}
