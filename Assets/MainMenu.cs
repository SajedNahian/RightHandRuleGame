using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.fullScreen = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButton ()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton ()
    {
        Application.Quit();
    }
}
