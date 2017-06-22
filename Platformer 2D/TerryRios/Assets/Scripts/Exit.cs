using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {

	private bool goUp = false;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator> ().SetTrigger ("exit");
			Invoke ("StartGoingUp", 0.7f);
			Invoke ("ChangeScene", 2.5f);
		}
	}
	

	// Update is called once per frame
	void Update () {
		if (goUp) {
			player.transform.Translate (0, 10*Time.deltaTime, 0);
		}
	}

	void StartGoingUp(){
		goUp = true;
	}
	void ChangeScene(){
		SceneManager.LoadScene ("winScreen");
	}
}
