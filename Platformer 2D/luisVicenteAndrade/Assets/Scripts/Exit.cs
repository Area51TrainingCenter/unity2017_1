using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public GameObject Player;
	public bool BayxD;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
		
	// Update is called once per frame
	void Update () {
		if (BayxD) {
			Player.transform.Translate (0, Time.deltaTime * 15 ,0);
			Invoke ("changeScene", 2f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			other.GetComponent <PlayerMovement> ().enabled = false;
			other.GetComponentInChildren <Animator> ().SetTrigger ("Exit");
			other.GetComponent<Rigidbody2D> (). velocity = Vector2.zero;
			Invoke ("exit", 1);
		}

	}
	void exit(){
		BayxD = true;
	}
	void changeScene(){
		SceneManager.LoadScene("Nivel3");
	}
}
