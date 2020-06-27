using UnityEngine;

public class GhostSpawner : TransformBehavior
{
	[SerializeField] Ghost ghostPrefab = default;
	Ghost[] ghosts;

	void Start()
	{
		float screenWidth = Boundaries.Width;
		float screenHeight = Boundaries.Height;

		Vector2[] offsetPositions = new Vector2[]
		{
			new Vector2(screenWidth, 0),
			new Vector2(screenWidth, screenHeight),
			new Vector2(0, screenHeight),
			new Vector2(-screenWidth, screenHeight),
			new Vector2(-screenWidth, 0),
			new Vector2(-screenWidth, -screenHeight),
			new Vector2(0, -screenHeight),
			new Vector2(screenWidth, -screenHeight)
		};

		ghosts = new Ghost[offsetPositions.Length];
		for (int i = 0; i < offsetPositions.Length; ++i)
		{
			Vector3 spawnPosition = (Vector2)trans.position + offsetPositions[i];
			var newObj = Instantiate(ghostPrefab, spawnPosition, trans.rotation);
			ghosts[i] = newObj.GetComponent<Ghost>();
			ghosts[i].SetParent(trans, offsetPositions[i]);
		}
	}

	void OnDestroy()
	{
		for (int i = 0; i != ghosts.Length; ++i)
		{
			Destroy(ghosts[i]);
		}
		ghosts = null;
	}
}