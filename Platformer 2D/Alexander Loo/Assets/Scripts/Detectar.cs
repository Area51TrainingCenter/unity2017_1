using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar : MonoBehaviour {
	
	public FollowPlayer _enemigo;
	void Start () {
		
	}
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			_enemigo.speed = 5;
		}
	}
}
