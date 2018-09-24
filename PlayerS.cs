using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour {
	// Use this for initialization
	public float speed =50f;
	public float jump_force=500f;
	private float fall_multiplier=2.5f;
	private float ground_dist;
	private Animator anim;
	private bool is_grounded;
	void Start () {
		anim = GetComponent<Animator> ();
		ground_dist=GetComponent<BoxCollider2D>().size.y;
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (5f, 5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement();	
		BetterJump ();
		//print ("velocity-"+GetComponent<Rigidbody2D> ().velocity);
	}

	void movement()//controls the movement of the player
	{
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			transform.localScale = new Vector3 (-1, 1, 1);
			anim.SetBool ("isRunning", true);
			}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			transform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool ("isRunning", true);
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A)) {
			anim.SetBool ("isRunning", false);		
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D)) {
			anim.SetBool ("isRunning", false);
		}


		if (Input.GetKeyDown (KeyCode.Space) && is_grounded) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f,jump_force));
		}
	}

	void BetterJump()
	{
		if (GetComponent<Rigidbody2D> ().velocity.y < 0) {
			GetComponent<Rigidbody2D> ().velocity += Vector2.up * Physics2D.gravity.y * (fall_multiplier) * Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "floor") {
			is_grounded = true;
			anim.SetBool ("isJumping", false);
		}			
	}

	void OnCollisionExit2D(Collision2D collisionInfo)
	{
		is_grounded = false;
		anim.SetBool ("isJumping", true);
	}
}
