using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	private GameObject player;
	private bool _animationfinished = false;

		// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (_animationfinished) {
			player.transform.Translate (0,10*Time.deltaTime,0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
		
			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator>().SetTrigger ("exit");
			Invoke ("elevate",1.5f);
			Invoke ("changescene",2);


		}
	}

	void elevate()
	{
		_animationfinished = true;
	}
		

	public void changescene(){

		SceneManager.LoadScene("win_screen");

	}
}
