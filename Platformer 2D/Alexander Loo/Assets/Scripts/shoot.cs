using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public float repeatRate;

	void Start(){
		InvokeRepeating ("Shooting", 0,repeatRate);
	}

	void Shooting(){
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}
}
