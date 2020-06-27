using UnityEngine;

public class Hyperjump : MonoBehaviour
{
	[SerializeField] LayerMask unsafeLayers = default;
	[SerializeField] float cooldown = 1f;
	[SerializeField] float postJumpInvincibilityTime = 0.5f;
	[SerializeField] AudioSource audioSource = default;
	[SerializeField] AudioClip hyperjumpAudio = default;
	float jumpCooldown = 5f;
	float jumpTime = 0f;
	float postJumpTime = 0.5f;

	GameObject playerObject;
	Rigidbody2D playerBody;
	Collider2D playerCollider;

	public void SetPlayer(GameObject player)
	{
		playerObject = player;
		playerBody = playerObject.GetComponent<Rigidbody2D>();
		playerCollider = playerObject.GetComponent<Collider2D>();

		jumpCooldown = cooldown;
		postJumpTime = 0f;
	}

	public void DoJump()
	{
		DoHyperjump();
	}

	private void OnEnable()
	{
		if (jumpCooldown <= 0f)
		{
			DoHyperjump();
		}
	}

	private void Update()
	{
		if (postJumpTime > 0f)
		{
			postJumpTime -= Time.deltaTime;
			if (postJumpTime <= 0f)
			{
				playerCollider.enabled = true;
			}
		}

		if (jumpCooldown > 0f)
		{
			jumpCooldown -= Time.deltaTime;
		}
		else if (Input.GetAxis("Vertical") < 0)
		{
			DoHyperjump();
		}
	}

	private void FixedUpdate()
	{
		if (jumpTime > 0f)
		{
			jumpTime -= Time.fixedDeltaTime;
			if (jumpTime <= 0f)
			{
				FinishJump();
			}
		}
	}

	void DoHyperjump()
	{
		jumpCooldown = cooldown;
		jumpTime = 0.5f;
		playerObject.SetActive(false);
		playerCollider.enabled = false;
		if (audioSource)
		{
			audioSource.PlayOneShot(hyperjumpAudio);
		}
	}

	void FinishJump()
	{
		playerObject.SetActive(true);
		var newPosition = GetSafeJumpPoint();
		playerBody.MovePosition(newPosition);
		jumpCooldown = cooldown;
		postJumpTime = postJumpInvincibilityTime;
	}

	Vector2 GetSafeJumpPoint()
	{
		Vector2 point = Boundaries.RandomInScreen();
		if (Physics2D.OverlapCircle(point, 3f, unsafeLayers))
		{
			return GetSafeJumpPoint();
		}
		return point;
	}
}