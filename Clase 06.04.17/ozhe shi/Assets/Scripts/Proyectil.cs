using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    public float speed = 1;
    public GameObject _prefab;
    public string targetTag;
    public float damage = 30;
	void Start () {

		
	}
	
	void Update () {
      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Health _health = other.GetComponent<Health>();
            _health.ModificarVida(damage);
 

            //destruimos el objeto que toca este trigger
            //  Destroy(other.gameObject);

            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_prefab,other.transform.position, other.transform.rotation);
        }
        
    }

}
