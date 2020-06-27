using UnityEngine;

public class PlayerLife : Health
{
	PlayerHandler playerHandler;

	public void Initialize(PlayerHandler handler)
	{
		playerHandler = handler;
	}

	public override void ApplyDamage(int damage)
	{
		Death();
	}

	void Death()
	{
		gameObject.SetActive(false);
		playerHandler.PlayerDeath();
	}
}