using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddBlock : MonoBehaviour, IBlock
{
	public float Evaluate(int frame, List<float> inputs){
		Debug.Log (inputs);
		return inputs.Sum(i => i);
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

    public List<string> InputDirections;
}
