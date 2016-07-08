//Modified code from Cassanis
﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;

	//jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;

	//for shooting
	public Transform gunTip;
	public GameObject hadouken;
	private float fireRate = 2f;
	private float nextFire = 0f;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

	}

	void Update(){
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			myRB.AddForce(new Vector2(0,jumpHeight));				
		}

		//player shooting
		if(Input.GetAxisRaw("Fire1")>0) fireRocket();
	}

	// Update is called once per frame
	void FixedUpdate () {

		//check if we are grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		myAnim.SetBool ("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);

		//Is the player pressing a button, if so get that value and put into move.
		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		//gets unatural movement, not actually using physics engine. Good for arcade game.
		myRB.velocity = new Vector2(move*maxSpeed,myRB.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		}
		else if(move < 0 && facingRight){
			flip ();
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//need to change fireball Object to facing left.
	void fireRocket(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
		}
			
			
	}
}
