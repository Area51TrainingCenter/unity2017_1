using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour {
	private float SaltoTrampolin = 8f;
	private GameObject _playerE;
	// Use this for initialization
	void Start () {
		
		_playerE = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")) {
			other.transform.Translate (0, 1 , 0);
			Invoke ("Tranpolin", 0.01f);
		}
	}

	void Tranpolin (){
		_playerE.GetComponent<PlayerControler> ().verticalSpeed = SaltoTrampolin;
	}
}
