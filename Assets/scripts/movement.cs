using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class movement : MonoBehaviour {

//public variables

public float speed = 10;
public float jumpForce = 5;
public float distanceToGround;
public bool IsGrounded;

//private variables
private Animator playerAnimator;
private Rigidbody2D playerRigidbody;
//private BoxCollider2D playerCollider;


	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponentInChildren<Animator> ();
		//playerCollider = GetComponent<BoxCollider2D> ();

		//distanceToGround = collider.bounds.extends.y;

		Assert.IsNotNull (playerRigidbody);
		//TODO assertion that speed floats have value.
		//Assert.IsNotNull (speed); //assertion must be refrence type. return to this later
	}
	
	void OnCollisionEnter2D(Collision2D coll)
 {
      IsGrounded = true;
 }
 
 void OnCollisionExit2D(Collision2D coll)
 {
      IsGrounded = false;
 }

	// Update is called once per frame
	void Update () {
		//horizontal and vertical keys set by default in input manager
		float moveHorizontal =Input.GetAxis ("Horizontal");
		//float moveVertical =Input.GetAxis ("Vertical");

		Vector2 move = new Vector2 (moveHorizontal,0); //vector2 shoud have the horizontal component and any vertical component desired.
		playerRigidbody.AddForce (move * speed);

		if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded) {
			Debug.Log("This jumped: ");
			playerRigidbody.velocity = new Vector2(0,0);
			playerRigidbody.AddForce (new Vector2(0,jumpForce), ForceMode2D.Impulse);
		}	

		if (Input.GetAxis ("Horizontal") > 0 || Input.GetAxis ("Horizontal") < 0){
			playerAnimator.Play ("walk");
		}
		else {
			playerAnimator.Play ("idle");
		}
		if (Input.GetAxis ("Horizontal") > 0){
		transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		if (Input.GetAxis ("Horizontal") < 0){
		transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}
}
