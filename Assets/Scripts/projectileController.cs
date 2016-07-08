//Modified code from Cassanis
﻿using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public float hadoukenSpeed;

	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D>();

		myRB.AddForce (new Vector2 (1, 0) * hadoukenSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
