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
		GameObject newBullet= Instantiate (bulletPrefab, transform.position, transform.rotation);
		newBullet.transform.rotation = transform.rotation;

	}
}
