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
		GameObject newBullet= Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		newBullet.transform.rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
