using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	[SerializeField] private float playerVel = 0;

	private Animator animator;

    private bool invincibility = false;
    public int invincibilityTime;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "crate" && invincibility == false)
        {
            this.GetComponent<Animator>().SetBool("Dead", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        else if (coll.gameObject.tag == "barrel" && invincibility == false && this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= coll.gameObject.GetComponent<WoodenObject>().velocityBroke)
        {
            this.GetComponent<Animator>().SetBool("Dead", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        else if (coll.gameObject.tag =="rhum")
        {
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
		if (GameManager.GM.GameState == GameManager.eGameState.PLAY)
		{
			transform.Translate (-this.transform.right * playerVel * Time.deltaTime * (GameManager.GM.terrainManager.CurrentAngle));
			if (GameManager.GM.terrainManager.CurrentAngle > 0)
				this.transform.localScale = new Vector3(-1, 1, 1);
			else if (GameManager.GM.terrainManager.CurrentAngle < 0)
				this.transform.localScale = new Vector3(1, 1, 1);
			//float currVel = (GameManager.GM.terrainManager.CurrentAngle / 100f) * playerVel * Time.deltaTime;
			//Debug.Log ("Vel = " + currVel);
			//rigidBody.velocity = new Vector2 (currVel, rigidBody.velocity.y);
			animator.SetFloat ("Velocity", Mathf.Abs(GameManager.GM.terrainManager.CurrentAngle));
		}
	}
}
