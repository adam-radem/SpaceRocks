using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : TransformBehavior
{
	[SerializeField] protected Ammunition ammunitionPrefab = default;
	[SerializeField] protected float shotCooldown = 0.25f;

	protected float _cooldown = 0f;

	protected void Fire()
	{
		Instantiate(ammunitionPrefab, trans.position, trans.rotation);
		_cooldown = shotCooldown;
	}
}
