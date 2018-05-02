using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddBlock : IBlock {
	public float Evaluate(int frame, List<float> inputs){
		return inputs.Sum();
	}

	public void SetInputDirections(List<string> dirs){
		InputDirections = dirs;
	}

	public List<string> InputDirections;
}
