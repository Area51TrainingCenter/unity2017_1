using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.U)) {
			PlayerPrefs.DeleteAll ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			Debug.Log ("Me cruce con player  se guardo su estado");
			PlayerPrefs.SetFloat ("CoorX", transform.position.x);
			PlayerPrefs.SetFloat ("CoorY",transform.position.y);
			Destroy (gameObject);
		}


	}
}
