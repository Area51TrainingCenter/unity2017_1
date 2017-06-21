using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float shootRate=0.0002f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Disparar", 0, shootRate);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Disparar(){
		GameObject newBullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		newBullet.transform.rotation = transform.rotation; 
	}



}
