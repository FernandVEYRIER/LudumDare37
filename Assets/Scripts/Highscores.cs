using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

    public Text container;

	// Use this for initialization
	void Start () {
        container.text = "";

        PlayerPrefs.SetInt("highScore1score", 12309129);
        PlayerPrefs.SetInt("highScore2score", 3211233);
        PlayerPrefs.SetInt("highScore3score", 123121);
        PlayerPrefs.SetInt("highScore4score", 12123);
        PlayerPrefs.SetInt("highScore5score", 1233);
        PlayerPrefs.SetInt("highScore6score", 123);
        PlayerPrefs.SetInt("highScore7score", 12);
        PlayerPrefs.SetInt("highScore8score", 1);
        PlayerPrefs.SetInt("highScore9score", -3);
        PlayerPrefs.SetInt("highScore10score", -19);

        PlayerPrefs.SetString("highScore1pseudo", "gaspar");
        PlayerPrefs.SetString("highScore2pseudo", "toto");
        PlayerPrefs.SetString("highScore3pseudo", "ttit");
        PlayerPrefs.SetString("highScore4pseudo", "kazji");
        PlayerPrefs.SetString("highScore5pseudo", "pazlsmqd");
        PlayerPrefs.SetString("highScore6pseudo", "ezpoids");
        PlayerPrefs.SetString("highScore7pseudo", "ezpfoizefpoxc");
        PlayerPrefs.SetString("highScore8pseudo", "ocnref");
        PlayerPrefs.SetString("highScore9pseudo", "ioccdjsknezui");
        PlayerPrefs.SetString("highScore10pseudo", "pokcdkeo");

        for (int highnum = 1; highnum <= 10; ++highnum)
        {
            string score = "highScore" + highnum.ToString() + "score";
            string pseudo = "highScore" + highnum.ToString() + "pseudo";

            Debug.Log("Pseudo: " + pseudo);
            Debug.Log("Score: " + score.ToString());
            if (!PlayerPrefs.HasKey(pseudo) || !PlayerPrefs.HasKey(score))
                return;
            container.text += PlayerPrefs.GetString(pseudo) + ": " + PlayerPrefs.GetInt(score).ToString() + "\n";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
