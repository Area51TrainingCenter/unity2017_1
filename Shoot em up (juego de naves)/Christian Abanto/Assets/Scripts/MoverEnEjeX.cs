using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnEjeX : MonoBehaviour {

    public float speedX = 5f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, 0, 0);
    }
}
