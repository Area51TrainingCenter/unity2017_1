using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	public float speed = 8;
	public GameObject _player;
	bool condicionUp = false;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (condicionUp) {
			Invoke ("UpPlayer", 0.2f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
					
			other.GetComponent<Movimiento> ().enabled = false;
			other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			other.GetComponentInChildren<Animator> ().SetTrigger ("exit");

			condicionUp = true;
		}

	}

	void UpPlayer(){
		_player.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}

}
