using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is meant to be created for things like the objective height, just give it a value to return every time
public class BaseBlock : MonoBehaviour, IBlock {

    public Text BaseText;

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
        return BaseVal;
    }

	//at frame 0 it should output 0 since it had no previous input
    public float BaseVal;
	public List<string> InputDirections;
    public List<string> OutputDirections;
}
