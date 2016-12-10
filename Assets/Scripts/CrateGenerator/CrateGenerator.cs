using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateGenerator : MonoBehaviour {
	public GameObject crate = null;
	public float spawnIntervalMax = 5.0f;
	public float spawnIntervalMin = 2.0f;
	private float nextSpawn;

	void Start () {
		if (crate == null)
			crate = (GameObject)Resources.Load("Prefabs/Barrel", typeof(GameObject));
		nextSpawn = Random.Range (spawnIntervalMin, spawnIntervalMax);
	}

	void Update () {
		if (nextSpawn <= 0) {
			GameObject obj = Instantiate (crate);
			obj.transform.SetParent (this.transform);
			obj.transform.position = this.transform.position;
			nextSpawn = Random.Range(spawnIntervalMin, spawnIntervalMax);
		}
		nextSpawn -= Time.deltaTime;
	}
}
