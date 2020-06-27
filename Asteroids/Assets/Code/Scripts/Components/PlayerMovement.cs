using UnityEngine;
using System.Collections;

public class PlayerMovement : Rigidbody2DBehavior
{
	[Header("Rotation")]
	[SerializeField] float rotationSpeed = 180f;
	float heading;

	[Header("Acceleration")]
	[SerializeField] float accelerationForce = 200f;
	float accel;

	[Header("Audio")]
	[SerializeField] AudioSource thrusterAudio = default;
	[SerializeField] float velocityAudioScale = 400f;

	[Header("VFX")]
	[SerializeField] SpriteRenderer thrusterSprite = default;
	[SerializeField] float velocityAlphaScale = 400f;

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		heading -= horizontal * rotationSpeed * Time.deltaTime;

		float vertical = Input.GetAxis("Vertical");
		if(vertical > 0)
		{
			accel = vertical * accelerationForce;
		}
		thrusterAudio.volume = Mathf.Clamp01(accel / velocityAudioScale);

		var color = thrusterSprite.color;
		color.a = Mathf.Clamp01(accel / velocityAlphaScale);
		thrusterSprite.color = color;
	}

	private void OnDisable()
	{
		accel = 0f;
		body.velocity = Vector2.zero;
	}


	private void FixedUpdate()
	{
		body.MoveRotation(heading);
		body.AddForce(trans.up * accel, ForceMode2D.Force);
	}
}