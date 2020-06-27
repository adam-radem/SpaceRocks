using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
	[SerializeField] Text[] scoreDisplays = default;

	private void OnEnable()
	{
		var allScores = HighScores.Scores;
		for (int i = 0; i != allScores.Length; ++i)
		{
			if (i >= scoreDisplays.Length)
			{
				break;
			}
			var score = allScores[i];
			var display = $"{score.playerName}................ {score.scoreValue:N0}";
			scoreDisplays[i].text = display;
		}
	}
}
