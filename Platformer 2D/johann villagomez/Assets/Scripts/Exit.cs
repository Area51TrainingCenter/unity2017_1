using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public GameObject player;
	public bool exit = false;

	// Use this for initialization
	void Start () {
		
			}
	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag("Player")){
			other.GetComponent<PlayerMovement>().enabled = false;
			other.GetComponentInChildren<Animator> ().SetTrigger ("Exit");
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			Invoke ("subir", 1);
			Invoke ("ChangeScene", 2);
		}
	}

	// Update is called once per frame
	void Update () {
		if (exit){
			player.transform.Translate (0, 10*Time.deltaTime , 0);
		}
	}
	void subir() {
		exit = true;
				}
	void ChangeScene() {
			SceneManager.LoadScene ("winScreen");
		}
}
