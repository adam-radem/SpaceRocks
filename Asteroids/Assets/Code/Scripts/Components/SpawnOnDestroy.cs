using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : TransformBehavior
{
    [SerializeField] GameObject[] spawned = default;
	bool isQuitting = false;

	private void OnApplicationQuit()
	{
		isQuitting = true;
	}

	private void OnDestroy()
	{
		if (isQuitting)
			return;

		if (Scorekeeper.IsGameOver)
			return;

		for(int i = 0; i != spawned.Length; ++i)
		{
			Instantiate(spawned[i], trans.position, trans.rotation);
		}
	}
}