using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float shootRate=1;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Disparar", 0, shootRate);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Disparar(){
		Instantiate (bulletPrefab, transform.position, transform.rotation);

	}



}
