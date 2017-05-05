using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    
    public string targetTag;
    public float damage = 30;
    public GameObject explosion;

	void Start () {
		
	}
	
	void Update () {
      

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            other.GetComponent<Health>().ModificarVida(damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        
    }
   

}
