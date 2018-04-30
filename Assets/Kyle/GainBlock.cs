using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBlock : IBlock {
	public float Evaluate(int frame){
		return Gain * Parents [0].Evaluate (frame);
	}

	public void AddParent(IBlock b){
		Parents.Add (b);
	}

	float Gain = 0;
	List<IBlock> Parents;

	public GainBlock(float gain, List<IBlock> parents){
		Gain = gain;
		Parents = parents;
	}
}
