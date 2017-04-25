using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDerecha : MonoBehaviour {
    public float speed = 0.5f;
    public GameObject _prefab2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed*Time.deltaTime, 0, 0);
    }

    // Other el objeto con que colisiona.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            //destruimos el objeto que toca este trigger
                    Destroy(other.gameObject);
                    // auto destruimos el objeto
                    Destroy(gameObject);
                    Instantiate(_prefab2, other.transform.position, other.transform.rotation);
              
        }

        
    }
}
