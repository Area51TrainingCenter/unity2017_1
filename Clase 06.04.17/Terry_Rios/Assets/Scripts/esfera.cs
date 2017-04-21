using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour {

    
    public float speedX = 6;
    public GameObject _prefab2;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Movimiento();

        
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(_prefab2, other.transform.position, other.transform.rotation);
        }
        
    }

    void Movimiento()
    {

        transform.Translate(speedX * Time.deltaTime, 0, 0);

    }
}
