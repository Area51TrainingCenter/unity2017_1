using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilPlayer : MonoBehaviour {

    public float speedX = 5;
    public GameObject _efecto;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speedX * Time.deltaTime, 0, 0);
    }

    // esta funcion va detectar cualquier cosa que entre en su volumen
    // OJO: antes, debes ir a Unity y en
        // Componente "Box Collider"
        // activar check 'Is Trigger'
    void OnTriggerEnter(Collider other)
    {
        // other, representa el objeto que ha tocado este elemento

        if ( other.CompareTag("enemigo") )
        {
            Instantiate(_efecto, transform.position, transform.rotation);
            Destroy(other.gameObject); // destruimos el objeto que toca ( cuadrado grande )
            Destroy(gameObject); // destruimos este objeto ( esta esfera )
        }
        // Nota: 
        // se crea un tag en: Panel Inspector / Tag 
        // luego lo recuperamos con: CompareTag("Nombretag")

    }
}
