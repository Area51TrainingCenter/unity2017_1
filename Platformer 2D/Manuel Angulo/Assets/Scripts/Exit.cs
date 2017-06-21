using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	private bool _exit = false;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (_exit) {
			Player.transform.Translate (0, 10 * Time.deltaTime, 0);	
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.CompareTag("Player")) {
			other.GetComponentInChildren<Animator>().SetTrigger("exit");
			other.GetComponent<PlayerMovement> ().enabled = false;
			//new Vector2 (0, 0) = VEctor2.zero
			other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Invoke ("Salidaaa", 0.9f); 
			Invoke ("changeScene", 1.5f);
		}
	
	}
	void Salidaaa (){
		_exit = true;
	}	
	void  changeScene (){
		SceneManager.LoadScene ("winScreen");
	}	
}
