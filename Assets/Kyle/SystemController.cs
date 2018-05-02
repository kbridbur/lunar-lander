using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour {
	void FixedUpdate () {
		//gets the thrust for the current frame
		float thrust = Root.Evaluate (I, new List<float>());
		I++;
	}
		
	int I=0;
	IBlock Root; //the output block
	List<IBlock> Blocks;

	public SystemController(IBlock root, List<IBlock> blocks){
		Root = root;
		Blocks = blocks;
	}
}
