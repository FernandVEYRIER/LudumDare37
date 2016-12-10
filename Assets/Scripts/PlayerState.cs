using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    private bool invincibility = false;
    public int invincibilityTime;
	// Use this for initialization
	void Start () {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "crate")
        {
            Destroy(coll.gameObject);
            if (invincibility == false)
            {
                this.GetComponent<Animator>().SetBool("Dead", true);
                Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }
        }
        else if (coll.gameObject.tag =="rhum")
        {
            Destroy(coll.gameObject);
            invincibility = true;
            StartCoroutine(CoroutineInvincibility());
            Invoke("resetInvincibility", invincibilityTime);
        }
    }

    IEnumerator CoroutineInvincibility ()
    {
        while (invincibility == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.1f);
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(.1f);
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void resetInvincibility()
    {
        invincibility = false;
    }

    // Update is called once per frame
    void Update () {
	}
}
