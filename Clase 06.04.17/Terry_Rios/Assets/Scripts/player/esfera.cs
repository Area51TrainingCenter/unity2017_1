using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour {
        
    public GameObject _prefab2;
    public string targettag;
    public float damage = 30;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targettag))
        {
            other.GetComponent<health>().ModificarVida(damage);

            Destroy(gameObject);
            Instantiate(_prefab2, transform.position,transform.rotation);
        }

        
           


    }

    
}
