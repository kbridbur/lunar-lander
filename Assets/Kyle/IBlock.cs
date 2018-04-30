public interface IBlock {
	float Evaluate (int frame);
	void AddParent (IBlock b);
}