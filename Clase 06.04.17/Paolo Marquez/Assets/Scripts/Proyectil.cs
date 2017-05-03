using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    
    public string targetTag;
    public GameObject _prefab;
    public float damage = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //convierte la velocidad por frames a velocidad por segundo
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {

            Debug.Log("Se hizo dano: " + other.name);
            Vida vidaOtro=other.GetComponent<Vida>();
            vidaOtro.ModificarDanio(damage);
            //Destroy(other.gameObject);
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
