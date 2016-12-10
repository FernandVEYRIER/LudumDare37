using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenObject : MonoBehaviour {

    public float velocityBroke;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (this.gameObject.tag == "crate")
        {
            this.GetComponent<Animator>().SetBool("Broken", true);
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        else if (this.gameObject.tag == "barrel" && this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= velocityBroke)
        {
            this.GetComponent<Animator>().SetBool("Broken", true);
            this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
