using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	public GameObject[] _instances;
	//prefab original d la bala que vamos a clonar
	public GameObject _prefab;
	// Use this for initialization
	void Start () {
		gameObject.name=_prefab.name+" pool";
		_instances = new GameObject[25];
		for (int i = 0; i < 25; i++) {
			//creamos la bala
			GameObject nuevaBala=(GameObject)Instantiate(_prefab);
			nuevaBala.SetActive(false);
			_instances[i]=nuevaBala;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//esta funcion se encarga de que la bala aparezca
	public GameObject Spawn (Vector3 pos, Quaternion rot) {
		for (int i = 0; i < 25; i++) {
			if (!_instances[i].activeSelf) {
				_instances [i].SetActive (true);
				_instances [i].transform.position = pos;
				_instances [i].transform.rotation = rot;
				return _instances [i];
			}
		}
		return null;
	}
}
