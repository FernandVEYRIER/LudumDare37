using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainManager : MonoBehaviour {

	[SerializeField] private float rotationVel = 10;
	[SerializeField] private float maxAngle = 45;


	private float rotation = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.GM.GameState == GameManager.eGameState.PLAY)
		{
			#if UNITY_ANDROID
			rotation += rotationVel * -Input.acceleration.x * Time.deltaTime;
			#else
			rotation += rotationVel * -Input.GetAxis("Horizontal") * Time.deltaTime;
			#endif

			rotation = Mathf.Clamp (rotation, -maxAngle, maxAngle);

			transform.localEulerAngles = new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, rotation);
		}
	}
}
