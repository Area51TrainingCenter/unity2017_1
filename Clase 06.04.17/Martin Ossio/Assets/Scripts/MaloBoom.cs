using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaloBoom : MonoBehaviour {
	public GameObject _prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//destruimos el objecto
			Destroy(other.gameObject);
			//destruimos el objecto nosotros
			Destroy(gameObject);


			Instantiate(_prefab, other.transform.position, other.transform.rotation);
       

		}

	}
}
