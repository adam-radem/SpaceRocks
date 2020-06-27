using UnityEngine;

public class PlayerWeapon : Weapon
{
	private void Update()
	{
		if (_cooldown <= 0f)
		{
			if (Input.GetButton("Weapon"))
			{
				Fire();
			}
		}
		else
		{
			_cooldown -= Time.deltaTime;
		}
	}
}