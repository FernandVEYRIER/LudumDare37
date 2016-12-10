using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGlass : MonoBehaviour {

    private float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 1f)
            Destroy(this.gameObject);
	}
}
