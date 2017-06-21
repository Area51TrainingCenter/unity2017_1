using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	private GameObject player;
	private bool exit;

	void Start(){
		player = GameObject.FindWithTag ("Player");
	}

	void Update(){
		if (exit) {
			player.transform.Translate (0, 10 * Time.deltaTime, 0);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			//player.GetComponentInChildren<Animator>(); se usa por si el objeto tiene hijo
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Animator> ().SetTrigger ("exit");
			//es lo mismo que player.GetComponent<Rigidbody2D>().velocity = new vector2(0,0);
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Invoke ("PlayerExit", 1);
			Invoke ("ChangeScene", 2);
		}
	}
	void PlayerExit(){
		exit = true;
	}
	void ChangeScene(){
		SceneManager.LoadScene ("winScreen");
	}
}
