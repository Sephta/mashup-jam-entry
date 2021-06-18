using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


[CreateAssetMenu(fileName = "Player Stats Asset", menuName = "ScriptableObjects/PlayerStats", order = 0)]
public class PlayerStatsSO : ScriptableObject
{
	/* ---------------------------------------------------------------- */
	/*                          Configurable Stats                      */
	/* ---------------------------------------------------------------- */
	[Header("Movement Stats")]
	[SerializeField] private float movementSpeed = 0f;

	[Header("Jump Stats")]
	[SerializeField, Range(0f, 500f)] private float jumpForce = 0f;
	[SerializeField, Range(0f, 5f)] private int numJumps = 0;


	/* ---------------------------------------------------------------- */
	/*                           Lambda Getters                         */
	/* ---------------------------------------------------------------- */
	public float MovementSpeed => movementSpeed;
	public float JumpForce => jumpForce;
	public int NumJumps => numJumps;

}
