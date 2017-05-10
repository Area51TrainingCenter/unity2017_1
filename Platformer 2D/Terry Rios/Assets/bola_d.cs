using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola_d : MonoBehaviour {
	

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			Destroy(other.gameObject);
			Destroy (gameObject);
		
		
		
		}
	
	
	
	
	
	
	
	}


}
