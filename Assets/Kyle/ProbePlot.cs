using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbePlot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GraphExtents = new Vector2(GraphBox.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, GraphBox.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
		input = manager.GetProbeCell ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (input.occupant == null) {
			return;
		}
		points.Add (input.occupant.GetFrameOutput(manager.frame-1));//get value from source
		if (points.Count > 100){
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
		if (Range [1] == Range [0]) {
			Range [1] = Range [0] + 1;
		}
		minText.text = Mathf.RoundToInt(Range [0]).ToString();
		maxText.text = Mathf.RoundToInt(Range [1]).ToString();
		for (int i = 0; i < points.Count; i++) {
			Vector2 coords = new Vector2 ();
			GameObject dot = Instantiate (Dot, new Vector2 (0, 0), Quaternion.identity);
			dot.transform.parent = GraphBox.transform;
			Vector2 b = new Vector2 (-GraphExtents.x + (2*GraphExtents.x) * i/100f, -GraphExtents.y + ((GraphExtents.y*2)*(points[i] - Range[0]))/(Range[1] - Range[0]));
			dot.transform.localPosition = new Vector3 (b.x, b.y, 0);
		}
	}

	List<float> GetRange(){
		float min = Mathf.Infinity;
		float max = 0;
		for (int i = 0; i < points.Count; i++) {
			if (points [i] < min) {
				min = points [i];
			} 
			if (points [i] > max) {
				max = points [i];
			}
		}
		return new List<float>{min, max};
	}

	Vector2 GraphExtents;
	List<float> points = new List<float>();
	public GameObject Dot;
	public GameObject GraphBox;
	public GameManager manager;
	public Cell input;

	public TextMesh minText;
	public TextMesh maxText;
}
