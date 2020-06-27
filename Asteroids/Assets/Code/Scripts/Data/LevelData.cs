using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Data", fileName = "New Level Data")]
public class LevelData : ScriptableObject
{
	[SerializeField] string levelName = default;
	[SerializeField] SpawnBehavior[] spawns = default;

	public void StartLevel()
	{
		Toast.Show(levelName, 4f);
		Timer.CreateTimer(0.5f, SpawnLevel);
	}

	void SpawnLevel()
	{
		for (int i = 0; i != spawns.Length; ++i)
		{
			spawns[i].Spawn();
		}
	}
}
