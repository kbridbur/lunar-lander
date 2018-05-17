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
		return ((transform.position.y - TopOfGround.transform.position.y + altitudeOffset) * 10);
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
			-.5f*(GetComponent<SpriteRenderer>().sprite.bounds.extents.y + Flame.GetComponent<SpriteRenderer> ().sprite.bounds.extents.y));
	}
	GameObject Flame;
	Rigidbody2D rb;
	public GameObject ThrustManager;
	public GameObject Ground;
    public GameObject TopOfGround;
    public float altitudeOffset;
}
