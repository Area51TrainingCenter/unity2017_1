using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour {
    public GameObject _bomba;

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
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);

            Instantiate(_bomba, transform.position, transform.rotation);

            
        }
    }
}