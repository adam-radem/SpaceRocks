using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawn Behavior", fileName = "New Spawn Behavior")]
public class SpawnBehavior : ScriptableObject
{	
	[SerializeField] SpawnBehaviorType spawnType = SpawnBehaviorType.FullScreen;
	[SerializeField] GameObject[] randomSpawns = default;
	[SerializeField] float delayTime = default;

	public void Spawn()
	{
		if(delayTime > 0f)
		{
			Scorekeeper.EnemySpawned();
			Timer.CreateTimer(delayTime, DelayedSpawn);
		}
		else
		{
			DoSpawn();
		}
	}

	void DelayedSpawn()
	{
		Scorekeeper.EnemyDestroyed();
		DoSpawn();
	}

	void DoSpawn()
	{
		switch (spawnType)
		{
			case SpawnBehaviorType.FullScreen:
				SpawnFullScreen();
				break;
			case SpawnBehaviorType.TopLeft:
				SpawnTopLeft();
				break;
			case SpawnBehaviorType.TopRight:
				SpawnTopRight();
				break;
			case SpawnBehaviorType.BottomLeft:
				SpawnBottomLeft();
				break;
			case SpawnBehaviorType.BottomRight:
				SpawnBottomRight();
				break;
			case SpawnBehaviorType.OffScreenHorizontal:
				SpawnOffScreenHorizontal();
				break;
			case SpawnBehaviorType.OffScreenVertical:
				SpawnOffScreenVertical();
				break;
		}
	}

	void SpawnAtPoint(Vector2 point, Vector2 direction)
	{
		var prefab = randomSpawns[Random.Range(0, randomSpawns.Length)];
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
		Instantiate(prefab, point, rotation);
	}

	void SpawnInRect(Rect rect)
	{
		Vector2 point = new Vector2(
			Random.Range(rect.xMin, rect.xMax),
			Random.Range(rect.yMin, rect.yMax)
		);

		//Don't spawn an enemy too close to the player
		if(Physics2D.OverlapCircle(point, 2f, 1 << LayerMask.NameToLayer("Player")))
		{
			SpawnInRect(rect);
			return;
		}

		SpawnAtPoint(point, Random.insideUnitCircle);
	}

	void SpawnFullScreen()
	{
		SpawnInRect(Boundaries.FullScreen);
	}

	void SpawnTopLeft()
	{
		var fullScreen = Boundaries.FullScreen;
		SpawnInRect(new Rect(fullScreen.xMin, 0, fullScreen.width / 2, fullScreen.height / 2));
	}

	void SpawnTopRight()
	{
		var fullScreen = Boundaries.FullScreen;
		SpawnInRect(new Rect(0, 0, fullScreen.width / 2, fullScreen.height / 2));
	}

	void SpawnBottomLeft()
	{
		var fullScreen = Boundaries.FullScreen;
		SpawnInRect(new Rect(fullScreen.xMin, fullScreen.yMin, fullScreen.width / 2, fullScreen.height / 2));
	}

	void SpawnBottomRight()
	{
		var fullScreen = Boundaries.FullScreen;
		SpawnInRect(new Rect(0, fullScreen.yMin, fullScreen.width / 2, fullScreen.height / 2));
	}

	void SpawnOffScreenHorizontal()
	{
		var fullScreen = Boundaries.FullScreen;
		int side = Random.Range(0, 2);
		Vector2 spawnPoint, direction;
		if(side == 0) //Spawn on left
		{
			spawnPoint = new Vector2(fullScreen.xMin - 1f, Random.Range(fullScreen.yMin, fullScreen.yMax));
			direction = Vector2.right;
		}
		else //Spawn on right
		{
			spawnPoint = new Vector2(fullScreen.xMax + 1f, Random.Range(fullScreen.yMin, fullScreen.yMax));
			direction = Vector2.left;
		}
		SpawnAtPoint(spawnPoint, direction);
	}

	void SpawnOffScreenVertical()
	{
		var fullScreen = Boundaries.FullScreen;
		int side = Random.Range(0, 2);
		Vector2 spawnPoint, direction;
		if (side == 0) //Spawn on top
		{
			spawnPoint = new Vector2(Random.Range(fullScreen.xMin, fullScreen.xMax), fullScreen.yMax + 1f);
			direction = Vector2.down;
		}
		else //Spawn on bottom
		{
			spawnPoint = new Vector2(Random.Range(fullScreen.xMin, fullScreen.xMax), fullScreen.yMin - 1f);
			direction = Vector2.up;
		}
		SpawnAtPoint(spawnPoint, direction);
	}
}

public enum SpawnBehaviorType
{
	FullScreen,
	TopLeft,
	TopRight,
	BottomLeft,
	BottomRight,
	OffScreenHorizontal,
	OffScreenVertical
}