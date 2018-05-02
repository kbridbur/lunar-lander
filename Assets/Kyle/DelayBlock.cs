﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBlock : MonoBehaviour, IBlock
{
	//Because the block may have multiple things calling Evaluate on it per frame we designate an output for each frame
	public float Evaluate (int frame, List<float> inputs){
		if (!FrameToInput.ContainsKey (frame)) {
			FrameToInput [frame] = inputs[0];
		}
		return FrameToInput [frame - 1];
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

    //at frame 0 it should output 0 since it had no previous input
    Dictionary<int, float> FrameToInput = new Dictionary<int, float>{{-1, 0f}};
	public List<string> InputDirections;
}
