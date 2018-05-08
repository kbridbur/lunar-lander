using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBlock : MonoBehaviour, IBlock
{
	public float Evaluate(int frame, List<float> inputs){
		FrameToOutput [frame] = Gain * inputs [0];
		return Gain * inputs[0];
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
		return FrameToOutput [frame];
	}

	//at frame 0 it should output 0 since it had no previous input
	Dictionary<int, float> FrameToOutput = new Dictionary<int, float>{{-1, 0f}};
    public float Gain = 0;
	public List<string> InputDirections;
}
