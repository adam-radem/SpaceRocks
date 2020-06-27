using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour
{
	[SerializeField] LevelData[] gameLevels = default;
	int currentLevel = -1;

	private void Start()
	{
		StartCoroutine(CheckLevelCompletion());
	}

	IEnumerator CheckLevelCompletion()
	{
		yield return new WaitForSeconds(1f);
		bool continueLevels = true;

		if (Scorekeeper.EnemyCount == 0)
		{
			continueLevels = AdvanceLevel();
		}

		if (continueLevels)
		{
			StartCoroutine(CheckLevelCompletion());
		}
	}

	bool AdvanceLevel()
	{
		currentLevel += 1;
		return StartLevel(currentLevel);
	}

	bool StartLevel(int levelNum)
	{
		if(levelNum >= gameLevels.Length)
		{
			Scorekeeper.Victory();
			return false;
		}
		else
		{
			var level = gameLevels[levelNum];
			level.StartLevel();
			return true;
		}
	}
}