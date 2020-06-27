using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Rigidbody2DBehavior
{
	[SerializeField] float velocity = 1f;

	private void OnEnable()
	{
		Scorekeeper.EnemySpawned();
		body.velocity = velocity * trans.up;
	}

	private void OnDisable()
	{
		Scorekeeper.EnemyDestroyed();
	}
}
