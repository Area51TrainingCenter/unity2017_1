using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFollow : MonoBehaviour {
	public GameObject elDormilon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			elDormilon.GetComponent<FollowPlayer>().speed = 1;
		}
	} 

	void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player")) {
			elDormilon.GetComponent<FollowPlayer>().speed = 0;
		}
	} 
}
