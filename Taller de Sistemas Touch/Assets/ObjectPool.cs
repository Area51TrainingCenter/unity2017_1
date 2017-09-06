using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	//prefab original de la bala que vamos a clonar
	public GameObject _prefab;
	//creamos una lista de las copias de la bala
	public GameObject[] _instances;

	// Use this for initialization
	void Start () {
		//cambiamos el nombre de este gameObject para que sea "Bullet pool"
		gameObject.name = _prefab.name + " pool";
		//creamos nuestro arreglo y fijamos la cantidad de elementos que tendrá
		_instances = new GameObject[25];
		for (int i = 0; i < 25; i++) {
			//creamos la bala
			GameObject newBullet = (GameObject) Instantiate (_prefab);
			//desactivamos la bala
			newBullet.SetActive (false);
			//colocamos la bala dentro del arreglo
			_instances [i] = newBullet;

		}
	}

	//esta funcion se encarga de que la bala aparezca
	public GameObject Spawn(Vector3 pos, Quaternion rot){
		for (int i = 0; i < 25; i++) {
			//preguntamos si esta copia de la bala esta apagada
			if (_instances[i].activeSelf == false) {
				_instances [i].SetActive (true);
				//colocamos la copia en la posicion que recibimos como parametro
				_instances [i].transform.position = pos;
				//igual hacemos con la rotacion
				_instances [i].transform.rotation = rot;
				//retornamos como resultado la copia
				return _instances [i];

			}
		}
		//si todas las copias estan siendo usadas... retornamos nulo
		return null;
	}
}
