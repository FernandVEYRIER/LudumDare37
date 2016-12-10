using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhum : MonoBehaviour {

    public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

        // Update is called once per frame
        void Update () {
		
	}
}
