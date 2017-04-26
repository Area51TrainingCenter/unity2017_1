using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruirPlayer : MonoBehaviour {
    public GameObject _prefab3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("jugador"))
        {
            Instantiate(_prefab3, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

    }
}
