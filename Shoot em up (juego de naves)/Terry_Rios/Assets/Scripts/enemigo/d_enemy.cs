using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_enemy : MonoBehaviour {

    public GameObject emuerte;
    health healthscript;
    Renderer _renderer;
    //esta variable nos da cuanta vida tenial el enemigo en el frame anterior
    float previoushealth;
    public GameObject[] _balasenemigo;
    public float frecuencia = 0.5f;
    public Transform[] _spawns;
    

	// Use this for initialization
	void Start () {
        healthscript = GetComponent<health>();
        previoushealth = healthscript.Health;
        _renderer = GetComponent<Renderer>();
        InvokeRepeating("Disparo", 0, frecuencia);

    }

    
    // Update is called once per frame
    void Update () {

        float enemyHealth = healthscript.Health;
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(emuerte, transform.position, transform.rotation);
        }

        if (previoushealth != healthscript.Health)
        {
            _renderer.material.color = Color.white;
            Invoke("restaurarcolor", 0.1f);
        }

        previoushealth = healthscript.Health;

    }

    void restaurarcolor()
    {
        _renderer.material.color = Color.red;
    }

    void Disparo()
    {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(_balaenemigo, transform.position, rotacion);
        
       for(int i = 0;i < _spawns.Length; i++)
        {
            for (int J = 0; J < _balasenemigo.Length; J++)
            {
                Instantiate(_balasenemigo[J], _spawns[i].position, _spawns[i].rotation);
            }
           
        }

    }
}
