using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
	float time = 1f;
	Action callback;

	private void Update()
	{
		time -= Time.deltaTime;
		if(time <= 0f)
		{
			callback?.Invoke();
			Destroy(gameObject);
		}
	}

	public static void CreateTimer(float time, Action callback)
	{
		var newTimer = new GameObject("Timer").AddComponent<Timer>();
		newTimer.time = time;
		newTimer.callback = callback;
	}
}