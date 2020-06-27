using System.Collections.Generic;
using UnityEngine;

public class LifeDisplayPanel : MonoBehaviour
{
	[SerializeField] GameObject lifeIcon = default;
	[SerializeField] Transform lifeParent = default;

	List<GameObject> currentIcons = new List<GameObject>();

	public void Setup(int playerLives)
	{
		for (int i = 0; i != playerLives; ++i)
		{
			AddLife();
		}
	}

	public void AddLife()
	{
		currentIcons.Add(Instantiate(lifeIcon, lifeParent, false));
	}

	public void RemoveLife()
	{
		int last = currentIcons.Count - 1;
		var lastIcon = currentIcons[last];
		Destroy(lastIcon);
		currentIcons.RemoveAt(last);
	}
}