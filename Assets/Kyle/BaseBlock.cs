using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is meant to be created for things like the objective height, just give it a value to return every time
public class BaseBlock : IBlock {
	public float Evaluate(int frame, List<float> inputs){
		return BaseVal;
	}

	public void SetInputDirections(List<string> dirs){
		InputDirections = dirs;
	}

	public float BaseVal;
	public List<string> InputDirections;
}
