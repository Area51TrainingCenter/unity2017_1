using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject[] balasEnemigo; //public GameObject es para abrir ventana para enlazar algo
    public GameObject _explota;
    public Transform[] spawns;
    public float FTiempo = 0.3f;
    Health vidaScript;
    Renderer _renderer;
    //Esta variable nos da cuanta vida tenia el enemigo en el frame anterior 
    float previaVida;

    // trasnform nos da acceso al compotente transform del objeto vacio
    public bool Estado = true;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo",0,FTiempo);
        vidaScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previaVida = vidaScript.vida;
    }
	
	// Update is called once per frame
	void Update () {
        float PlayerVida = vidaScript.vida;
        if (PlayerVida <= 0)
        {
            Destroy(gameObject);
            Instantiate(_explota, transform.position, transform.rotation);
        }
        if (previaVida != vidaScript.vida)
        {
            _renderer.material.color = Color.white;
            Invoke("RegresarColor", 0.05f);
           
        }
        //y aca se actuaiza por el valor actual
        previaVida = vidaScript.vida;

    }
    void RegresarColor() {
        _renderer.material.color = Color.red;
    } 

    void Disparo() {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(balaEnemigo, transform.position, rotacion);
        //Instantiate(balaEnemigo, spawn.position, spawn.rotation);

        for (int i = 0; i < spawns.Length ; i++)
        {
            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], spawns[i].position, spawns[i].rotation);
            }
          
        }
    }
   
}
