using System.Collections.Generic;
public interface IBlock {
	float Evaluate (int frame, List<float> inputs);
	void SetInputDirections(List<string> dirs);
    List<string> GetInputDirections();
    List<string> GetOutputDirections();
    void RotateClockwise();
	float GetFrameOutput(int frame);
}