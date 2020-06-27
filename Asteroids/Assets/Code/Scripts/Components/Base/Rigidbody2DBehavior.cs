using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DBehavior : TransformBehavior
{
	[SerializeField] protected Rigidbody2D body = default;

	protected override void OnValidate()
	{
		base.OnValidate();
		if (!body)
		{
			body = GetComponent<Rigidbody2D>();
		}
	}
}
