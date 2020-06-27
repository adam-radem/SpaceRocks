using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Rigidbody2DBehavior
{
	[SerializeField] float initialVelocity = 1f;

	private void OnEnable()
	{
		Vector2 dir = Random.insideUnitCircle.normalized;
		body.velocity = dir * initialVelocity;
		Scorekeeper.EnemySpawned();
	}

	private void OnDisable()
	{
		Scorekeeper.EnemyDestroyed();
	}
}
