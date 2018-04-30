using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is meant to be created for things like the objective height, just give it a value to return every time
public class BaseBlock : IBlock {
	public float Evaluate(int frame){
		return BaseVal;
	}

	public void AddParent(IBlock b){}

	float BaseVal;

	public BaseBlock(float value){
		BaseVal = value;
	}
}
