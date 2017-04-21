using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoxD : MonoBehaviour {

    float speedx = 5f;
    float speedy = 0f;
    public GameObject _explota;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {

            //Se destruye el objeto
            Destroy(other.gameObject);
            //Autodestruccion
            Destroy(gameObject);
            Instantiate(_explota, other.transform.position, other.transform.rotation);
        }

     
    }
}
