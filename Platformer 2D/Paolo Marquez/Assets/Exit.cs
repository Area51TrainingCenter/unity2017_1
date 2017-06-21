using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	private GameObject player;
	private winMenu menu;
	private bool elevacion=false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
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
		SceneManager.LoadScene ("winScreen");
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Colisiono con algo");
		if (other.gameObject.CompareTag("Player")) {
			Debug.Log ("Colisiono con player");
			player.GetComponent<Rigidbody2D>().velocity=new Vector3(0,0,0);
			player.GetComponent<PlayerMovement> ()._animator.SetTrigger("salir");
			//player.GetComponentInChildren<Animator> ().enabled = false;
			player.GetComponent<PlayerMovement> ().enabled = false;
			Invoke ("activarElevacion", 1.6f);
			Invoke ("irseDeNivel", 2.6f);
		}
	}

}
