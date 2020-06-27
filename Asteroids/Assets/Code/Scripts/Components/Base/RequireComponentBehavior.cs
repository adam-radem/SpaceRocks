using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
	[SerializeField] protected Transform trans = default;

	protected virtual void OnValidate()
	{
		if (!trans)
		{
			trans = transform;
		}
	}
}
