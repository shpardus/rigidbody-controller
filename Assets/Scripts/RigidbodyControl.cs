using UnityEngine;
using System.Collections;

public class RigidbodyControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// FixedUpdate is called every __ seconds, Edit >> Projejct Settings >> Time >> Fized Timestep
	void FixedUpdate () {
		// When 'W' key is pressed, goes straight
		if ( Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ) {
			//GetComponent<Rigidbody>().AddForce (new Vector3(0f, 0f, 2f), ForceMode.VelocityChange );
			// Changed so the foward direction is different as capsule rotates
			GetComponent<Rigidbody>().AddForce( GetComponent<Transform>().forward * 2f, ForceMode.VelocityChange );
		}
		else if ( Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) ) {
			GetComponent<Rigidbody>().AddForce( GetComponent<Transform>().forward * -1, ForceMode.VelocityChange );
		}
		// When the 'W' key isn't pressed, set the velocity to gravity. 
		else {
			GetComponent<Rigidbody>().velocity = Physics.gravity;
		}

		// TURNING
		// Because the rigidbody component's rotation is frozen, we can't use physics's torque. Need to create it.
		if ( Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) ) {
			transform.Rotate (new Vector3 (0f, -5f, 0f) );
		}
		else if ( Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) ) {
			transform.Rotate (new Vector3 (0f, 5f, 0f) );
		}

		// JUMPING
		if ( Input.GetKeyDown (KeyCode.Space) ) {
			GetComponent<Rigidbody>().AddForce (new Vector3(0f, 10000f, 0f), ForceMode.Acceleration );
		}
	}
}
