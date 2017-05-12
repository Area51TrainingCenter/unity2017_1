using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_speed : MonoBehaviour {

	public GameObject enemy_sphere;



	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	}



	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag ("Player")) 
		{
			
			enemy_sphere.GetComponent<follow_player> ().speed = 3;

		}
	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag ("Player")) {

			enemy_sphere.GetComponent<follow_player> ().speed = 0;


		}
	}


}
