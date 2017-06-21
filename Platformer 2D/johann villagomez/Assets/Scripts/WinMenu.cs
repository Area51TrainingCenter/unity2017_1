using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos el codigo para el manejo de escenas
using UnityEngine.SceneManagement;
public class WinMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
