using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

	[SerializeField] private float rotationVel = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.GM.GameState == GameManager.eGameState.PLAY)
		{
			transform.Rotate (new Vector3 (0, 0, rotationVel * -Input.GetAxis("Horizontal") * Time.deltaTime));
		}
	}
}
