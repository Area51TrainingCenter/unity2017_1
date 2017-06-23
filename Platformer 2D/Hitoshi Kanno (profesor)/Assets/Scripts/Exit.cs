using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {
	
	private bool goUp = false;
	private GameObject player;
	//este booleando nos permite saber si es que el player ha tocado el trigger
	private bool touchedTrigger = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			//hacemos esto para que el player ya no se pueda mover
			//en horizontal y para permitir que caiga al piso
			player.GetComponent<PlayerMovement> ().canControl = false;
			touchedTrigger = true;

		}
	}
	

	// Update is called once per frame
	void Update () {
		
		if (player.GetComponent<PlayerMovement>().isGrounded && touchedTrigger) {
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator> ().SetTrigger ("exit");
			Invoke ("StartGoingUp", 1.7f);
			Invoke ("ChangeScene", 3.5f);
			//regresamos esto a falso para que ya no se siga ejecutando el contenido de este if
			touchedTrigger = false;
		}

		if (goUp) {
			player.transform.Translate (0, 10*Time.deltaTime, 0);
		}
	}

	void StartGoingUp(){
		goUp = true;
	}
	void ChangeScene(){
		int score = GameObject.FindObjectOfType<ScoreManager> ().score;
		PlayerPrefs.SetInt ("playerScore", score);

		SceneManager.LoadScene ("winScreen");
	}
}
