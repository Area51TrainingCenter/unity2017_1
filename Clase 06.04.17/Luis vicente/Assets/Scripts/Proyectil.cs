using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    public float speed = 5;
    public GameObject _explota;
    // String representa el tag del objeto que queremos destruir
    public string targetTag;
    // Use this for initialization
    void Start () {

	}    
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0 * Time.deltaTime, 0);      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            //Se destruye el objeto
            Destroy(other.gameObject);
            //Autodestruccion
            Destroy(gameObject);
            Instantiate(_explota, other.transform.position, other.transform.rotation);
        }   
    }
}
