using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum eGameState
	{ WARMUP, PLAY, PAUSE }

	public eGameState GameState
	{ get { return _gameState; } }

	public static GameManager GM;

	[Header("HUD")]
	[SerializeField] private GameObject panelPause = null;

	private eGameState _gameState = eGameState.PLAY;
	private eGameState _gameStatePrev = eGameState.PLAY;

	void Awake()
	{
		GM = this;
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
			_gameState = eGameState.PAUSE;
			Time.timeScale = 0;
		}
		_gameStatePrev = _gameState;
	}
}
