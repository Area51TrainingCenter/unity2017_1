using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public GameObject Player;
	public ScoreManager _ScoreManager;
	public bool BayxD;
	private bool toucherTrigger = false;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		_ScoreManager = GameObject.Find ("Score Manager") . GetComponent <ScoreManager>();

	}
		
	// Update is called once per frame
	void Update () {
		if (Player.GetComponent<PlayerMovement>().isGrounded && toucherTrigger) {
			Player.GetComponent<PlayerMovement> ().enabled = false;
			Player.GetComponentInChildren <Animator> ().SetTrigger ("Exit");
			Player.GetComponent<Rigidbody2D> (). velocity = Vector2.zero;
			Invoke ("exit", 2);
			Invoke ("changeScene", 3f);
			toucherTrigger = false;
		}
		if (BayxD) {
			Player.transform.Translate (0, Time.deltaTime * 15 ,0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			Player.GetComponent<PlayerMovement> ().canControl = false;
			toucherTrigger = true;
		}

	}
	void exit(){
		BayxD = true;
	}
	void changeScene(){
		PlayerPrefs.SetInt("PlayerScore",_ScoreManager.score);
		SceneManager.LoadScene("Nivel3");
	}

}
