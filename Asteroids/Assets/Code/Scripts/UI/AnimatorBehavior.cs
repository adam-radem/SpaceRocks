using UnityEngine;

public class AnimatorBehavior : MonoBehaviour
{
	[SerializeField] protected Animator animator;

	private void OnValidate()
	{
		if (!animator)
		{
			animator = gameObject.GetComponent<Animator>();
		}
	}
}
