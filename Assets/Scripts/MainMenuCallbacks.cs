using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClickControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void OnClickHighscores()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
