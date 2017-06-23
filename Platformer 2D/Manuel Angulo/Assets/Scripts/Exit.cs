﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	private bool _exit = false;
	public GameObject Player;
	private bool touchedTrigger = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame


	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.CompareTag("Player")) {
			//hacemos esto para q el player ya no se pueda mover
			//en horizontal y para permitir que caiga al piso
			Player.GetComponent<PlayerMovement> ().canControl = false;
			touchedTrigger = true;
		}
	
	}

	void Update () {

		if (Player.GetComponent<PlayerMovement>().isGrounded) {
			Player.GetComponentInChildren<Animator>().SetTrigger("exit");
			Player.GetComponent<PlayerMovement> ().enabled = false;
			//new Vector2 (0, 0) = VEctor2.zero
			Player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Invoke ("Salidaaa", 0.9f); 
			Invoke ("changeScene", 1.5f);
		}


		if (_exit) {
			Player.transform.Translate (0, 10 * Time.deltaTime, 0);	
		}

	}
	void Salidaaa (){
		_exit = true;
	}	
	void  changeScene (){
		SceneManager.LoadScene ("winScreen");
	}	
}
