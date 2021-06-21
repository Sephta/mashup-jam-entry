using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, ] private Rigidbody2D _rb = null;
	[SerializeField, Expandable, Required] private PlayerStatsSO _playerStats = null;

	[SerializeField] private float soundTimer = 0f;
	[SerializeField, ReadOnly] private float currSoundTime = 0f;

	[Space(25)]
	[SerializeField, ReadOnly] private InputManager iManager = null;
	[SerializeField, ReadOnly] private StaticGroundedManager iGrounded = null;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		if (_rb == null)
			_rb = GetComponent<Rigidbody2D>();
	}

    void Start()
	{
		if (InputManager._inst != null)
			iManager = InputManager._inst;

		if (StaticGroundedManager._inst != null)
			iGrounded = StaticGroundedManager._inst;
		
		currSoundTime = soundTimer;
	}

    // void Update()
	// {
	// 	UpdateSoundTimer();

	// 	// use audio clip with index 1
	// 	if (currSoundTime <= 0f && iGrounded.isGrounded)
	// 	{
	// 		PlayRunSound();
	// 		currSoundTime = soundTimer;
	// 	}
	// }

	void FixedUpdate()
	{
		MovePlayer();
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void MovePlayer()
	{
		Vector2 newVelocity = iManager.direction * _playerStats.MovementSpeed;

		_rb.velocity = new Vector3(newVelocity.x,
                                   _rb.velocity.y);
	}

	private void PlayRunSound()
	{
		if (AudioManager._inst != null)
			AudioManager._inst.PlaySFX(1);
	}

	private void UpdateSoundTimer()
	{
		currSoundTime = Mathf.Clamp((currSoundTime - Time.deltaTime), 0f, soundTimer);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
