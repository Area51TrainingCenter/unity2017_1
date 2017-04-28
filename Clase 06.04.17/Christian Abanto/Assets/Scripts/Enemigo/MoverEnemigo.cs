using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour {

    public float speedY = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* CHRISTIAN: mi code es maaaaas largo :(
        if (estado)
        {
            if (transform.position.y <= 3)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else
            {
                estado = false;
            }
        }
        else
        {
            if (transform.position.y >= -3)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            else
            {
                estado = true;
            }

        }
        */

        // PROFE: su code mas cooorto :)
        // hace que suba y baje el enemigo        
            if (transform.position.y >=  3) { speedY = -speedY; }
            if (transform.position.y <= -3) { speedY = -speedY; }
            transform.Translate(0, speedY * Time.deltaTime, 0);
        
    }
}
