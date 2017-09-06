using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject _bulletPrebab;
	public ObjectPool _bulletPool;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateBullet",0,0.1f);
		Debug.Log("mi archivo es: "+(_bulletPrebab.name+" pool"));
		_bulletPool=GameObject.Find (_bulletPrebab.name+" pool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
		//detectamos la barra espaciadora
		if (Input.GetKey(KeyCode.Space)) {
			
		}
	}

	void CreateBullet () {
		_bulletPool.Spawn (transform.position,transform.rotation);
		//Instantiate (_bulletPrebab, transform.position, transform.rotation);
	}
}
