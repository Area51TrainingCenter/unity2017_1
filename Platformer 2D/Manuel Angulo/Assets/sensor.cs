using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour {
	public string targetTag;
	public GameObject _padre;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag(targetTag)) 
		{
			_padre.GetComponent<FollowPlayer> ().speed=2;
		}
	}
	/*void OnTriggerExit (Collider other) 
		{
			if (other.CompareTag(targetTag)) 
			{
				_padre.GetComponent<FollowPlayer> ().speed=0;
			}
	
	}*/
}
