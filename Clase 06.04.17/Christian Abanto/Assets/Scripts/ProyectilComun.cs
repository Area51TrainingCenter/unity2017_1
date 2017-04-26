using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilComun : MonoBehaviour
{
    public float speedX = 5f;
    public GameObject _explosion;
    // este representara el tag que buscamos destruir
    public string targetTag; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, 0, 0);
    }

    
    // esta funcion va detectar cualquier cosa que entre en su volumen
    // OJO: antes, debes ir a Unity y en
    // Componente "Box Collider"
    // activar check 'Is Trigger'
    void OnTriggerEnter(Collider other)
    {
        // other, representa el objeto que ha tocado este elemento ( Zona Lenta )
        // Debug.Log(other.name);

        if (other.CompareTag(targetTag))
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(other.gameObject); // destruimos el objeto que toca ( cuadrado grande )
            Destroy(gameObject); // destruimos este objeto ( esta esfera )
        }

    }
}
