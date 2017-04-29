using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour {
	private bool blown;

	// Use this for initialization
	void Start () {
		blown = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (!blown) {
			GetComponent<Animator> ().SetBool ("blowing", true);
			blown = true;
		}
	}
}
