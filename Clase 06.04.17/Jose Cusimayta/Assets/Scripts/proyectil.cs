using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
    public float speed = 5;
    //este representa cuál es el tag del objeto que buscamos destruir
    public string targetTag;
    public GameObject _explosion;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, transform.rotation);
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
