using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
	static GameObject GameOverPrefab { get; set; }

	[SerializeField] GameObject highScoreEntry = default;
	[SerializeField] GameObject highScoreDisplay = default;

	private void OnEnable()
	{
		var finalScore = Scorekeeper.CurrentScore;
		if (HighScores.IsHighScore(finalScore))
		{
			highScoreEntry.SetActive(true);
			highScoreDisplay.SetActive(false);
		}
		else
		{
			highScoreEntry.SetActive(false);
			highScoreDisplay.SetActive(true);
		}
	}

	public static void Show()
	{
		if (!GameOverPrefab)
		{
			GameOverPrefab = Resources.Load<GameObject>("GameOverScreen");
		}

		Instantiate(GameOverPrefab);
	}
}
