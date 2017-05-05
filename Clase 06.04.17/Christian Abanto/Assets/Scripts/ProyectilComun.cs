using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilComun : MonoBehaviour
{
    
    public GameObject _explosion;
    // este representara el tag que buscamos destruir
    public string targetTag;
    // determina el daño de modo publico
    public float daniar = 30;

    // Use this for initialization
    void Start()
    {

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
            // INSTANCIAR
            //Instantiate(_explosion, transform.position, transform.rotation);

            // DESMINUIR VIDA
            other.GetComponent<PuntosVida>().ModificarVida(daniar);

            // DESTRUIR
            //Destroy(other.gameObject); // destruimos el objeto que toca ( cuadrado grande )
            Destroy(gameObject); // destruimos este objeto ( esta esfera )
        }
    }
}
