using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    //game object es una clase que representa un objeto en el juego
    public GameObject _prefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool keyWPressed = Input.GetKeyDown(KeyCode.Space);
        if (keyWPressed)
        {
            Instantiate(_prefab, transform.position, transform.rotation);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_prefab, transform.position, transform.rotation);
        }
    }


}
