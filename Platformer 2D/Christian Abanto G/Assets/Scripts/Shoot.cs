using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public GameObject bulletPrefab;
	public float _delayBullet = 1;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreatebullePrefab", 0 ,_delayBullet);
	}

	void CreatebullePrefab() {
		Instantiate (bulletPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
