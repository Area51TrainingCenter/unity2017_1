using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	//esta es la bala que vamos a crear
	public GameObject _bulletPrefab;
	//este es el pool de donde vamos a sacar las balas
	private ObjectPool _bulletPool;
	private bool shoot;
	// Use this for initialization
	void Start () {
		//esto hace que cada 0.1 segundos se ejecute
		//la funcion CreateBullet
		InvokeRepeating ("CreateBullet", 0, 0.1f);
		//buscamos el pool de las balas. Formamos el nombre juntando el nombre de la bala con la palabra "pool"
		_bulletPool = GameObject.Find (_bulletPrefab.name + " pool").GetComponent<ObjectPool> ();
	}
	
	// Update is called once per frame
	void Update () {
		//detectamos cuando la barra espaciadora 
		//esta siendo presionada
		if (Input.GetKey (KeyCode.Space)) {
			shoot = true;
		} else {
			shoot = false;
		}
	}

	//esta funcion crea una bala
	void CreateBullet(){
		if (shoot) {
			_bulletPool.Spawn (transform.position, transform.rotation);	
		}
	}
}
