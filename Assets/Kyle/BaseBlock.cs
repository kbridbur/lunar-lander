using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is meant to be created for things like the objective height, just give it a value to return every time
public class BaseBlock : MonoBehaviour, IBlock {
	public float Evaluate(int frame, List<float> inputs){
		return BaseVal;
	}

	public void SetInputDirections(List<string> dirs){
		InputDirections = dirs;
	}

    public List<string> GetInputDirections()
    {
        return InputDirections;
    }

    public void RotateClockwise()
    {
        List<string> newDirections = new List<string>();
        foreach (string direction in InputDirections)
        {
            if (direction.Equals("up"))
            {
                newDirections.Add("right");
            }
            if (direction.Equals("right"))
            {
                newDirections.Add("down");
            }
            if (direction.Equals("down"))
            {
                newDirections.Add("left");
            }
            if (direction.Equals("left"))
            {
                newDirections.Add("up");
            }
        }
        this.InputDirections = newDirections;
    }

	public float GetFrameOutput(int frame){
		return BaseVal;
	}

	//at frame 0 it should output 0 since it had no previous input
    public float BaseVal;
	public List<string> InputDirections;
}
