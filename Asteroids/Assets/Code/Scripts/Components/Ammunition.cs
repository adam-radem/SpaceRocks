using UnityEngine;

public class Ammunition : Rigidbody2DBehavior
{
	[SerializeField] float velocity = 1;

	private void OnEnable()
	{
		body.velocity = transform.up * velocity;
	}
}