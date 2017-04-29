using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class movement : MonoBehaviour {

//public variables

public float speed = 10;
public float jumpForce = 5;
public bool isGrounded;

//private variables

private Rigidbody2D playerRigidbody;
private bool jump = false;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();

		Assert.IsNotNull (playerRigidbody);
		//TODO assertion that speed floats have value.
		//Assert.IsNotNull (speed); //assertion must be refrence type. return to this later
	}
	
	// Update is called once per frame
	void Update () {
		//horizontal and vertical keys set by default in input manager
		float moveHorizontal =Input.GetAxis ("Horizontal");
		//float moveVertical =Input.GetAxis ("Vertical");

		Vector2 move = new Vector2 (moveHorizontal,0); //vector2 shoud have the horizontal component and any vertical component desired.
		playerRigidbody.AddForce (move * speed);

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			Debug.Log("This jumped: ");
			playerRigidbody.velocity = new Vector2(0,0);
			playerRigidbody.AddForce (new Vector2(0,jumpForce), ForceMode2D.Impulse);
		}	
	}
}
