using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	private GameObject player;
	private winMenu menu;
	private bool elevacion=false;
	private bool touchedTrigger = false;
	private ScoreManager _score;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		_score= GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerMovement>().isGrounded && touchedTrigger) {
			player.GetComponent<Rigidbody2D>().velocity=new Vector3(0,0,0);
			player.GetComponent<PlayerMovement> ()._animator.SetTrigger("salir");
			//player.GetComponentInChildren<Animator> ().enabled = false;
			player.GetComponent<PlayerMovement> ().enabled = false;
			Invoke ("activarElevacion", 2f);
			Invoke ("irseDeNivel", 3.5f);
			touchedTrigger = false;
		}

		if (elevacion) {
			activarElevacion ();
		}
	}

	public void activarElevacion() {
		elevacion=true;
		player.transform.Translate (Vector3.up);
	}

	public void irseDeNivel()
	{
		PlayerPrefs.SetInt ("playerScore", _score.score);
		SceneManager.LoadScene ("winScreen");
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Colisiono con algo");
		if (other.gameObject.CompareTag("Player")) {
			touchedTrigger = true;
			player.GetComponent<PlayerMovement> ().canControl = false;
			Debug.Log ("Colisiono con player");


		}
	}

}
