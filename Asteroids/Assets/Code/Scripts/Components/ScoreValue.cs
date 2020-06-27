using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValue : MonoBehaviour
{
    [SerializeField] int scoreValue = 1000;

	private void OnDestroy()
	{
		Scorekeeper.AddScore(scoreValue);
	}
}
