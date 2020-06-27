using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
	[SerializeField] Text scoreDisplay = default;
	int _cachedScore;
	int currentScore => Scorekeeper.CurrentScore;

	private void Start()
	{
		scoreDisplay.text = "000";
	}

	private void Update()
	{
		if(_cachedScore != currentScore)
		{
			_cachedScore = Math.Min(_cachedScore + 7, currentScore);
			scoreDisplay.text = _cachedScore.ToString("N0");
		}
	}
}
