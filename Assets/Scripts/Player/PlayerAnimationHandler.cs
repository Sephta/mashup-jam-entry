using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using NaughtyAttributes;


public class PlayerAnimationHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Required] private Animator _anim = null;

	public static UnityAction TriggerPlayerJumpAnimation;

	[Space(25)]
	[SerializeField, ReadOnly] private InputManager iManager = null;
	[SerializeField, ReadOnly] private StaticGroundedManager iGrounded = null;
	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		if (_anim == null)
			_anim = GetComponentInChildren<Animator>();
	}

	void OnEnable()
	{
		TriggerPlayerJumpAnimation += SetAnimatorJumpTrigger;
	}

	void OnDisable()
	{
		TriggerPlayerJumpAnimation -= SetAnimatorJumpTrigger;
	}

    void Start()
	{
		if (InputManager._inst != null)
			iManager = InputManager._inst;

		if (StaticGroundedManager._inst != null)
			iGrounded = StaticGroundedManager._inst;
	}

    void Update()
	{
		UpdatePlayerAnimator();
	}

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private bool PlayerIsMoving => (iManager.direction.x != 0);
	private void UpdatePlayerAnimator()
	{
		if (iGrounded == null || iManager == null) return;

		_anim.SetBool("isGrounded", iGrounded.isGrounded);

		_anim.SetBool("isMoving", PlayerIsMoving);
	}

	private void SetAnimatorJumpTrigger() => _anim.SetTrigger("jump");

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
