using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBlock : IBlock {
	//Because the block may have multiple things calling Evaluate on it per frame we designate an output for each frame
	public float Evaluate (int frame){
		if (!FrameToInput.ContainsKey (frame)) {
			FrameToInput [frame] = Parents [0].Evaluate (frame);
		}
		return FrameToInput [frame - 1];
	}

	public void AddParent(IBlock b){
		Parents.Add (b);
	}

	//at frame 0 it should output 0 since it had no previous input
	Dictionary<int, float> FrameToInput = new Dictionary<int, float>{{-1, 0f}};
	List<IBlock> Parents;

	public DelayBlock(List<IBlock> parents){
		Parents = parents;
	}
}
