using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	[SerializeField] int weaponDamage = 1;
	public int WeaponDamage => weaponDamage;
	[SerializeField] int hitCount = 1;
	bool damageActive = true;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!damageActive)
		{
			return;
		}

		var health = collision.collider.GetComponent<Health>();
		if (health)
		{
			Hit(health);
		}
	}

	void Hit(Health target)
	{
		target.ApplyDamage(WeaponDamage);
		hitCount -= 1;
		if (hitCount == 0)
		{
			damageActive = false;
			Destroy(gameObject);
		}
	}
}
