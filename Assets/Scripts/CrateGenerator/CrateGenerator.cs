using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateGenerator : MonoBehaviour {
	public GameObject []crates;
	public float spawnIntervalMaxStart = 10.0f;
	public float spawnIntervalMinStart = 8.0f;
	public float spawnIntervalMaxEnd = 5.0f;
	public float spawnIntervalMinEnd = 2.0f;
	public float timeFromStartToEnd = 60.0f;
	private float time;
	private float nextSpawn;

	void Start () {
		nextSpawn = Random.Range (spawnIntervalMinStart, spawnIntervalMaxStart);
		time = timeFromStartToEnd;
	}

	void Update () {
		if (nextSpawn <= 0) {
			GameObject obj = Instantiate (crates[Random.Range(0, crates.Length)]);
			obj.transform.SetParent (this.transform);
			obj.transform.position = this.transform.position;
			float spawnInterMin = (spawnIntervalMinStart - spawnIntervalMinEnd) * (time / timeFromStartToEnd) + spawnIntervalMinEnd;
			float spawnInterMax = (spawnIntervalMaxStart - spawnIntervalMaxEnd) * (time / timeFromStartToEnd) + spawnIntervalMaxEnd;
			nextSpawn = Random.Range(spawnInterMin, spawnInterMax);
			Debug.Log ("Min: " + spawnInterMin + " | Max: " + spawnInterMax + " | time: " + time);
		}
		nextSpawn -= Time.deltaTime;
		time = Mathf.Max (0, time - Time.deltaTime);
	}
}
