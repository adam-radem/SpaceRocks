using UnityEngine;

public class AutomaticWeapon : Weapon
{
	private void OnEnable()
	{
		_cooldown = shotCooldown;
	}

	private void Update()
	{
		if (_cooldown <= 0f)
			Fire();
		_cooldown -= Time.deltaTime;
	}
}
