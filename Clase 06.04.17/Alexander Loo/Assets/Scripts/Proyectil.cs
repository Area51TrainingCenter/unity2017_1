using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    public float speed = 1;
    public GameObject _prefab;
    public string targetTag;
	void Start () {
		
	}
	
	void Update () {
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {                
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_prefab,other.transform.position, other.transform.rotation);
        }
        
    }

}
