using UnityEngine;

public class LookAtPlayer : TransformBehavior
{
	Transform target;

	void FindPlayer()
	{
		var playerObj = GameObject.FindGameObjectWithTag("Player");
		if (playerObj)
		{
			target = playerObj.transform;
		}
	}

	private void Update()
	{
		if (!target)
		{
			FindPlayer();
		}
		else
		{
			trans.up = target.position - trans.position;
		}
	}
}