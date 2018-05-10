using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		Flame =gameObject.transform.GetChild (0).gameObject;
		Debug.Log (Flame);
	}

	public float GetHeight(){
		return transform.position.y - Ground.transform.position.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float thrust = ThrustManager.GetComponent<GameManager> ().GetThrust ();
		rb.AddForce (new Vector2(0, thrust));
		AdjustFlame (thrust);
	}

	void AdjustFlame(float t){
		float scaleConst = Mathf.Clamp(.3f * Mathf.Log(t), 0f, 1f);
		Flame.transform.localScale = new Vector2(scaleConst, scaleConst);
		Flame.transform.localPosition = new Vector2(0, 
			-(GetComponent<SpriteRenderer>().bounds.extents.y + 3*Flame.GetComponent<SpriteRenderer> ().bounds.extents.y));
	}
	GameObject Flame;
	Rigidbody2D rb;
	public GameObject ThrustManager;
	public GameObject Ground;
}
