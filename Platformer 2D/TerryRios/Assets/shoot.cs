using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	
	public GameObject bulletprefab;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("shootbullet", 0, 3);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void shootbullet()
	{
		Instantiate (bulletprefab, transform.position, Quaternion.identity); 

	}

}
