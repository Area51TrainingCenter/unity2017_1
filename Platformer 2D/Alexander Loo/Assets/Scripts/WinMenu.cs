using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos el código para manejo de escenas
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

	public void ChangeScene(string sceneName){
		//esta función sirve para cambiar de escena
		SceneManager.LoadScene (sceneName);
	}
}
