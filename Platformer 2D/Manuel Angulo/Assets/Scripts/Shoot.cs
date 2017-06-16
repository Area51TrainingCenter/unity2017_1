using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float shootRate = 3.0f;
	// Use this for initialization
	void Start () {
		//Quaternion.identity es como poner rotacion 0 en todo
		InvokeRepeating("ShootBullet",0,shootRate);
	}
	
	// Update is called once per frame
	void ShootBullet () {
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}
}
