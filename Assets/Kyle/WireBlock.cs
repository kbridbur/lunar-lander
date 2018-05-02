using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBlock : MonoBehaviour, IBlock {

    public float Evaluate(int frame, List<float> inputs)
    {
        return inputs[0];
    }

    public void SetInputDirections(List<string> dirs)
    {
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
