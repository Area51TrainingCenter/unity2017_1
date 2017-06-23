using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {

	private int Score = 0;

	private bool goUp = false;
	private GameObject player;
	private GameObject ScoreManager;

	private bool touchedTrigger = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		ScoreManager = GameObject.Find("Score manager");

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			player.GetComponent<PlayerMovement> ().canControl = false;
			touchedTrigger = true;
		}
	}
	

	// Update is called once per frame
	void Update () {

		if (player.GetComponent<PlayerMovement> ().isGrounded && touchedTrigger) {
			
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator> ().SetTrigger ("exit");
		
			Invoke ("StartGoingUp", 1.2f);
			Invoke ("ChangeScene", 3.2f);
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
		Score = ScoreManager.GetComponent<ScoreManager> ().score;
		PlayerPrefs.SetInt("playerScore", Score);

		SceneManager.LoadScene ("winScreen");
	}
}
