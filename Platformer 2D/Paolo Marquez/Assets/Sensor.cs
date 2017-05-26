using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			bullet.GetComponent<FollowPlayer> ().speed = 5;
		}
	}
}
