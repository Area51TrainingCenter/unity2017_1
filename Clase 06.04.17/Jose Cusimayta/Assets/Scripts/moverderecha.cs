using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverderecha : MonoBehaviour {

    int velocidad_proyectil=6;
    public GameObject _prefab_explosion;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoverDerecha();
    }
    void MoverDerecha()
    {
        transform.Translate(velocidad_proyectil * Time.deltaTime, 0, 0);
    }
    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemigo")
        {
            //Destruir al enemigo
            Destroy(other.gameObject);
            //Destruir la bala
            Destroy(gameObject);
            Instantiate(_prefab_explosion, other.transform.position, transform.rotation);
        }
        
        
    }
}
