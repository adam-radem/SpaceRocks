using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scorekeeper
{
	public static int CurrentScore { get; private set; }
	public static int EnemyCount { get; private set; }
	public static bool IsGameOver { get; private set; }

	public static void NewGame()
	{
		CurrentScore = 0;
		IsGameOver = false;
	}

	public static void Victory()
	{
		Toast.Show("Congratulations!\nYou are victorious!", Mathf.Infinity);
		GameOverScreen.Show();
		IsGameOver = true;
	}

	public static void GameOver()
	{
		Toast.Show("Game Over!\nYou have lost!", Mathf.Infinity);
		GameOverScreen.Show();
		IsGameOver = true;
	}

	public static void AddScore(int points)
	{
		CurrentScore += points;
	}

	public static void SubmitScore(string name)
	{
		HighScores.ReportScore(name, CurrentScore);
	}

	public static void EnemySpawned()
	{
		++EnemyCount;
	}

	public static void EnemyDestroyed()
	{
		--EnemyCount;
	}
}
