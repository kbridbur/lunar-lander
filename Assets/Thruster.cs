using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (new Vector2(0, Thrust));
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("wtf");
	}

	Rigidbody2D rb;
	public float Thrust=0;
}
