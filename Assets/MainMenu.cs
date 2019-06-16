using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// prevent full screen
	void Start () {
        Screen.fullScreen = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // play button handler
    public void PlayButton ()
    {
        SceneManager.LoadScene("Game");
    }

    // quit button handler
    public void QuitButton ()
    {
        Application.Quit();
    }
}
