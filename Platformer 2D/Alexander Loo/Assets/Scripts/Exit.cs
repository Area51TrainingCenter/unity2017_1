using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	private GameObject player;
	private bool exit;
	private bool touchTrigger = false;
	private ScoreManager scoreManager;

	void Start(){
		player = GameObject.FindWithTag ("Player");
		//Para buscar un componente
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			touchTrigger = true;
			player.GetComponent<PlayerMovement> ().controlPlayer = false;
			//player.GetComponentInChildren<Animator>(); se usa por si el objeto tiene hijo
		}
	}
	void Update(){
		//Si el player toca el trigger y está en el piso
		if (player.GetComponent<PlayerMovement> ().isGrounded && touchTrigger) {
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Animator> ().SetTrigger ("exit");
			//es lo mismo que player.GetComponent<Rigidbody2D>().velocity = new vector2(0,0);
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Invoke ("PlayerExit", 1.5f);
			Invoke ("ChangeScene", 2.5f);
			touchTrigger = false;
		}
		if (exit) {
			player.transform.Translate (0, 10 * Time.deltaTime, 0);
		}
	}
	//OnTriggerEnter solo se activa una vez cuando entra la trigger
	void PlayerExit(){
		exit = true;
	}
	void ChangeScene(){
		//Guardar una variable de tipo INT en la memoria
		PlayerPrefs.SetInt ("playerScore", scoreManager.score);
		SceneManager.LoadScene ("winScreen");
	}
}
