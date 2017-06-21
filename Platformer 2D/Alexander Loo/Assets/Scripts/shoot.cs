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
		//Al guardar el Instantiate en una variable igual se llama la función
		GameObject newBullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		newBullet.transform.rotation = transform.rotation;
	}
}
