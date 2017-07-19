using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour {

	private GameObject _player;
	private float newverticalspeed = 20;

	// Use this for initialization
	void Start () {

		_player = GameObject.FindGameObjectWithTag ("Player");
				
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag("Player")) {

			_player.transform.Translate (0,1,0);

			Invoke ("Trampolin",0.1f);

		}




	}

	void Trampolin(){

		_player.GetComponent<PlayerControl> ().verticalSpeed = newverticalspeed;
	}


}
