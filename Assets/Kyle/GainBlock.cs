using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBlock : IBlock {
	public float Evaluate(int frame, List<float> inputs){
		return Gain * inputs[0];
	}

	public void SetInputDirections(List<string> dirs){
		InputDirections = dirs;
	}

	public float Gain = 0;
	public List<string> InputDirections;
}
