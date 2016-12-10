using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay()
    {
        Debug.Log("Play");
    }

    public void OnClickControls()
    {
        Debug.Log("Controls");
    }

    public void OnClickHighscores()
    {
        Debug.Log("Highscores");
    }

    public void OnClickCredits()
    {
        Debug.Log("Credits");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
