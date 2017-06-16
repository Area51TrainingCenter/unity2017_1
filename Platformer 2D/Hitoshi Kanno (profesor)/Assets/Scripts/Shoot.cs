using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float shootRate = 3.0f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("ShootBullet", 0, shootRate);
	}
	
	void ShootBullet () {
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}
}
