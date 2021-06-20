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

	[Space(25)]
	[SerializeField, ReadOnly] private InputManager iManager = null;

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
	}

    // void Update(){}

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


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
