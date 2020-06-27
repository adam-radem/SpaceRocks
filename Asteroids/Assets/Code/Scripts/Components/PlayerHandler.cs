using UnityEngine;

public class PlayerHandler : TransformBehavior
{
	[SerializeField] int playerLives = 3;
	[SerializeField] GameObject playerPrefab = default;
	[SerializeField] Hyperjump hyperjump = default;
	[SerializeField] LifeDisplayPanel lifeDisplayPanel = default;
	[SerializeField] AudioSource audioSource = default;
	[SerializeField] AudioClip playerDeathClip = default;

	PlayerLife _currentPlayer;

	private void Start()
	{
		SpawnInitialPlayer();
		Scorekeeper.NewGame();
	}

	public void SpawnInitialPlayer()
	{
		var newPlayer = Instantiate(playerPrefab, trans.position, trans.rotation);
		_currentPlayer = newPlayer.GetComponent<PlayerLife>();
		_currentPlayer.Initialize(this);

		lifeDisplayPanel.Setup(playerLives);
		hyperjump.SetPlayer(newPlayer);
	}

	public void PlayerDeath()
	{
		playerLives -= 1;
		lifeDisplayPanel.RemoveLife();

		if (audioSource)
		{
			audioSource.PlayOneShot(playerDeathClip);
		}

		if(playerLives > 0)
		{
			RespawnPlayer();
		}
		else
		{
			Scorekeeper.GameOver();
		}
	}

	public void RespawnPlayer()
	{
		hyperjump.Invoke("DoJump", 2f);
	}
}
