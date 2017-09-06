using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// OnEnable se ejecuta cada vez que la bala se activa
	void OnEnable () {
		//accedemos al componente Rigidbody en la bala
		//y hacemos que su velocidad sea para arriba
		GetComponent<Rigidbody> ().velocity = Vector3.up * 20;
		//ejecutamos la funcion DestroyBullet 2 segundos despues de que la bala aparece
		Invoke("DestroyBullet", 2);
	}
	
	void DestroyBullet () {
		//desactivamos la bala
		gameObject.SetActive (false);
	}
}
