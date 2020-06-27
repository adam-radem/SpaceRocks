using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] int healthPoints = 1;
	public int HealthPoints => healthPoints;

	public virtual void ApplyDamage(int damage)
	{
		healthPoints -= damage;
		if (healthPoints <= 0)
		{
			Destroy(gameObject);
		}
	}
}