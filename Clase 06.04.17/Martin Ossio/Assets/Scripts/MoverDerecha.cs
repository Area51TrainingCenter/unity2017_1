using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDerecha : MonoBehaviour {
	public GameObject _prefab;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemigo"))
		{
			//destruimos el objecto
			Destroy(other.gameObject);
			//destruimos el objecto nosotros
			Destroy(gameObject);


			Instantiate(_prefab, other.transform.position, other.transform.rotation);
       

		}

	}
}
