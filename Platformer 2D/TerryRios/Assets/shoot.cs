using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	
	public GameObject bulletprefab;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("shootbullet", 0, 3.0f);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void shootbullet()
	{
		GameObject newBullet = Instantiate (bulletprefab, transform.position, Quaternion.identity); 

		newBullet.transform.rotation = transform.rotation;

	}

}
