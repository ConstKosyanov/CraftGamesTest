using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text tilesTextBox;
	public Text cristalsTextBox;

	public void ShowScore(ScoreModel model)
	{
		tilesTextBox.text = $"Tiles: {model.Tiles}";
		cristalsTextBox.text = $"Cristals: {model.Cristals}";
	}
}
