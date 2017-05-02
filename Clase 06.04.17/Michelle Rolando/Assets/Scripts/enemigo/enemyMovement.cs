using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    public float speedX = 2f;
    public float speedY = 0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CambioPosicion ();
        CambioPosicion2 ();
    }

    void CambioPosicion()
    {
        //el "transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);" se declara una vez 
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

        if (transform.position.y >= 2.5)
        {
            speedY = speedY * -1;
            //speedY = -2;(otra forma de hacerlo)
        }
        if (transform.position.y <= -3)
        {
            speedY = speedY * -1;
            //speedY = 2;
        }

    }

    void CambioPosicion2 ()
    {
        //el "transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);" se declara una vez 
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

        if (transform.position.x >= 2)
        {
            speedY = speedX * -1;
            //speedY = -2;(otra forma de hacerlo)
        }
        if (transform.position.y <= -2)
        {
            speedY = speedX * -1;
            //speedY = 2;
        }

    }
}
