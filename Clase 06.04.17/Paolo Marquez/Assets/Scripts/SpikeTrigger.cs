using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {
    public Rigidbody _prefab;
    //public GameObject explo;

	// Use this for initialization
	void Start () {
        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Entro: " + other.name);
            _prefab.isKinematic = false;
            Destroy(this.gameObject);
            //destruimos el objeto
            //Destroy(gameObject);
           // Instantiate(explo, other.transform.position, other.transform.rotation);
        }


    }
}
