using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, ] private Rigidbody2D _rb = null;
	[SerializeField, Expandable, Required] private PlayerStatsSO _playerStats = null;
	[SerializeField] private ParticleSystem _dustFX = null;

	[Header("Configurable Jump Data"), Space(25)]
	[SerializeField, ReadOnly] private int currJumpCount = 0;

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

		currJumpCount = _playerStats.NumJumps;
	}

	/* -------------------------------------------------------------------
	 * Allows for more expressive and readable code using the
	 * lambda declaration operator to return a understandable bool.
	*/
	private bool PlayerCanJump => (currJumpCount > 0) || iGrounded.isGrounded;
	private bool PlayerPressedJumpKey => Input.GetKeyDown(iManager._keyBindings[InputAction.jump]);
	/* ---------------------------------------------------------------- */

    void Update()
	{
		UpdateJumpCounter();

		if (PlayerCanJump && PlayerPressedJumpKey)
		{
			currJumpCount = Mathf.Clamp((currJumpCount - 1), 0, _playerStats.NumJumps);

			_rb.velocity = new Vector2(_rb.velocity.x,
									   _playerStats.JumpForce * Time.fixedDeltaTime);
			
			if (_dustFX != null) _dustFX.Play();
		}
	}

	void FixedUpdate()
	{
		_rb.velocity += (_rb.velocity.y < 0) ? _playerStats.GravityDefault * _playerStats.GravityMultiplier * Time.fixedDeltaTime : _playerStats.GravityDefault * Time.fixedDeltaTime;
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void UpdateJumpCounter()
    {
        if (iGrounded.isGrounded && !(_rb.velocity.y > 0))
        {
            currJumpCount = _playerStats.NumJumps;
        }
    }

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
