using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speedX = 10;
    public string targetTag;
    public GameObject _prefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //convierte la velocidad por frames a velocidad por segundo
        transform.Translate(speedX * Time.deltaTime, 0, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {

            Debug.Log("Se destruyo: " + other.name);
            Destroy(other.gameObject);
            //destruimos el objeto
            Destroy(gameObject);
            Instantiate(_prefab, other.transform.position, other.transform.rotation);
        }

       
    }

    void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1;
        Debug.Log("Salio a la zona: " + other.name);
    }
}
