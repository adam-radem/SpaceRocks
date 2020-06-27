using UnityEngine;

public class Ghost : TransformBehavior
{
	Transform followTransform;
	Vector3 followOffset;

	Vector3 followPosition => followTransform.position + followOffset;

	public void SetParent(Transform parent, Vector2 offset)
	{
		followTransform = parent;
		followOffset = offset;
		Follow();
	}

	private void LateUpdate()
	{
		Follow();
	}

	void Follow()
	{
		trans.rotation = followTransform.rotation;
		trans.position = followPosition;
	}
}
