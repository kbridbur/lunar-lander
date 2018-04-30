using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddBlock : IBlock {
	public float Evaluate(int frame){
		return Parents.Sum (i => i.Evaluate (frame));
	}

	public void AddParent(IBlock b){
		Parents.Add (b);
	}

	List<IBlock> Parents;

	public AddBlock(List<IBlock> parents){
		Parents = parents;
	}
}
