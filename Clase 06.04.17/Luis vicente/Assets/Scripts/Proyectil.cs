using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    // String representa el tag del objeto que queremos destruir
    public GameObject _explota;
    public string targetTag;
    public float dano = 30;
    // Use this for initialization
    void Start () {

	}    
	// Update is called once per frame
	void Update () {
           
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            //Se destruye el objeto
            //Autodestruccion
            Health playerVida = other.GetComponent<Health>();
            playerVida.ModificarVida(dano);
            Destroy(gameObject);
            Instantiate(_explota, other.transform.position, other.transform.rotation);
        }   
    }
}
