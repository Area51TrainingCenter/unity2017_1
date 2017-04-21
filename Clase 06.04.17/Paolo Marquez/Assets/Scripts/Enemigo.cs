using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public GameObject _prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Se destruyo: " + other.name);
            Destroy(other.gameObject);
            //destruimos el objeto
            Destroy(gameObject);
            Instantiate(_prefab, other.transform.position, other.transform.rotation);
        }



    }
}
