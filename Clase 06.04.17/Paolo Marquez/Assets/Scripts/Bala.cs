using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {
    int contador = 0;

    public Bala()
    {
        transform.Translate(contador, 0, 0);
    }

    // Use this for initialization
    void Start () {
        transform.Translate(contador, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1;
        transform.Translate(contador, 0, 0);
    }
}
