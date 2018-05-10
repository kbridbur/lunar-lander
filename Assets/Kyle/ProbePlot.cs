using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbePlot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GraphExtents = new Vector2(GraphBox.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, GraphBox.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		points.Add (Source.GetComponent<GameManager>().GetThrust());//get value from source
		if (points.Count > 50){
			points.RemoveAt (0);
		}
		SpriteRenderer[] s = GraphBox.GetComponentsInChildren<SpriteRenderer> ();
		for (int i = 0; i < s.Length; i++) {
			GameObject obj = s[i].gameObject;
			if (obj != GraphBox) {
				Destroy (obj);
			}
		}
		DisplayPlot ();
	}

	void DisplayPlot(){
		List<float> Range = GetRange ();
		for (int i = 0; i < points.Count; i++) {
			Vector2 coords = new Vector2 ();
			GameObject dot = Instantiate (Dot, new Vector2 (0, 0), Quaternion.identity);
			dot.transform.parent = GraphBox.transform;
			//Debug.Log ((Range [0] + (Range [1] - Range [0]) * points [i]));
			Vector2 b = new Vector2 (-GraphExtents.x + (2*GraphExtents.x) * i/50f, -GraphExtents.y + ((GraphExtents.y*2)*(points[i] - Range[0]))/(Range[1] - Range[0]));
			dot.transform.localPosition = new Vector3 (b.x, b.y, 0);
		}
	}

	List<float> GetRange(){
		float min = Mathf.Infinity;
		float max = -Mathf.Infinity;
		for (int i = 0; i < points.Count; i++) {
			if (points [i] < min) {
				min = points [i];
			} else if (points [i] > max) {
				max = points [i];
			}
		}
		return new List<float>{Mathf.Clamp(min, 0, 50000), Mathf.Clamp(max, 10, 50000)};
	}

	Vector2 GraphExtents;
	List<float> points = new List<float>();
	public GameObject Source;
	public GameObject Dot;
	public GameObject GraphBox;
}
