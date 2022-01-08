public delegate void ScoreCapturedDelegate(ScoreType type);

public enum ScoreType { Tile, Cristal }

public class ScoreModel
{
	public int Tiles { get; set; }
	public int Cristals { get; set; }
}