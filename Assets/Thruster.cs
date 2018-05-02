using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	public float GetHeight(){
		return transform.position.y - Ground.transform.position.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (new Vector2(0, ThrustManager.GetComponent<GameManager>().GetThrust()));
	}

	Rigidbody2D rb;
	public GameObject ThrustManager;
	public GameObject Ground;
}
