using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum eGameState
	{ WARMUP, PLAY, PAUSE }

	public eGameState GameState
	{ get { return _gameState; } }

	public static GameManager GM;

	[Header("HUD")]
	[SerializeField] private GameObject panelPause = null;
	[SerializeField] private Text textScore;

	private eGameState _gameState = eGameState.PLAY;
	private eGameState _gameStatePrev = eGameState.PLAY;

	[SerializeField] private TerrainManager _terrainManager;
	public TerrainManager terrainManager {
		get { return _terrainManager; }
	}

	public int Score {
		get {
			return (int)_score;
		}
	}

	private float _score = 0;

	void Awake()
	{
		GM = this;
	}

	void Update()
	{
		if (_gameState == eGameState.PLAY)
		{
			_score += Time.deltaTime * 2f;
			textScore.text = Score.ToString();
		}
	}

	public void LoadLevel(int level)
	{
		SceneManager.LoadSceneAsync (level);
	}

	public void Pause()
	{
		if (_gameState == eGameState.PAUSE)
		{
			if (panelPause != null)
				panelPause.SetActive (false);
			_gameState = _gameStatePrev;
			Time.timeScale = 1;
		}
		else
		{
			if (panelPause != null)
				panelPause.SetActive (true);
			_gameStatePrev = _gameState;
			_gameState = eGameState.PAUSE;
			Time.timeScale = 0;
		}
	}

	void AddScore(int value)
	{
		_score += value;	
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
