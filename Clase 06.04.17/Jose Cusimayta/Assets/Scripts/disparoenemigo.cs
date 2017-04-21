using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoenemigo : MonoBehaviour {
    public GameObject _prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destruir al enemigo
            Destroy(other.gameObject);
            //Destruir la bala
            Destroy(gameObject);
            Instantiate(_prefab, other.transform.position, transform.rotation);
        }
    }
}
