using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;// prefab de la bala
	// Use this for initialization
	public float shooRate=3.0f;

	void Start () {
		InvokeRepeating ("bullet()",0,shooRate);
	}
	

	void bullet () {
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}



}
