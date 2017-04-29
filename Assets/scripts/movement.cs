using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class movement : MonoBehaviour {

//public variables

public float speed;

//private variables
private Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();

		Assert.IsNotNull (playerRigidbody);
		//TODO assertion that speed floats have value.
		//Assert.IsNotNull (speed); //assertion must be refrence type. return to this later
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//horizontal and vertical keys set by default in input manager
		float moveHorizontal =Input.GetAxis ("Horizontal");
		float moveVertical =Input.GetAxis ("Vertical");
		Vector2 move = new Vector2 (moveHorizontal,moveVertical);
		playerRigidbody.AddForce (move * speed);
	}
}
