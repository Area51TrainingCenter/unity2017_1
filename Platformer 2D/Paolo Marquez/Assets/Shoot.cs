using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float shootRate = 3.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("creaBala",0,shootRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void creaBala(){
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}
}
