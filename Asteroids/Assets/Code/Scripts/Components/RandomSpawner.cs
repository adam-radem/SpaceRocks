using UnityEngine;

public class RandomSpawner : TransformBehavior
{
	public GameObject[] spawnable;

	public void Start()
	{
		var obj = spawnable[Random.Range(0, spawnable.Length)];
		if (obj)
		{
			Instantiate(obj, trans.position, trans.rotation);
		}
		Destroy(gameObject);
	}
}