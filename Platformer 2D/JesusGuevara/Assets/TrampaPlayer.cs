using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPlayer : MonoBehaviour {

	public GameObject objeto ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		

		if (other.CompareTag("Player"))
		{	
			//Debug.Log ("Entro en la Trampa"+ objeto.GetComponent<FollowPlayer> ().speed);
			objeto.GetComponent<FollowPlayer> ().speed = 10;
	
		}
	}

}
