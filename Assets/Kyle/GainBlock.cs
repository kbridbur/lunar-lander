using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainBlock : MonoBehaviour, IBlock
{
    public Text GainText;

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

    public List<string> GetOutputDirections()
    {
        return OutputDirections;
    }

    List<string> rotateListClockwise(List<string> directions)
    {
        List<string> newDirections = new List<string>();
        foreach (string direction in directions)
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
        return newDirections;
    }

    public void RotateClockwise()
    {
        this.InputDirections = rotateListClockwise(InputDirections);
        this.OutputDirections = rotateListClockwise(OutputDirections);
    }

    public float GetFrameOutput(int frame){
        if (FrameToOutput.ContainsKey(frame))
        {
            return FrameToOutput[frame];
        }
        return 0;
		
	}

	//at frame 0 it should output 0 since it had no previous input
	Dictionary<int, float> FrameToOutput = new Dictionary<int, float>{{-1, 0f}};
    public float Gain = 0;
	public List<string> InputDirections;
    public List<string> OutputDirections;
}
