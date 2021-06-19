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
	[SerializeField] private Vector2 gravityDefault = Vector2.zero;
	[SerializeField, Range(0f, 5f)] private float gravityMultiplier = 0f;

	[Header("Jump Stats")]
	[SerializeField, Range(0f, 500f)] private float jumpForce = 0f;
	[SerializeField, Range(0f, 5f)] private int numJumps = 0;

	[Header("Seed + Water Stats")]
	[SerializeField] private int numSeeds = 0;
	[SerializeField, Range(0f, 100f)] private float maxWaterLevel = 0f;


	/* ---------------------------------------------------------------- */
	/*                           Lambda Getters                         */
	/* ---------------------------------------------------------------- */
	public float MovementSpeed => movementSpeed;
	public Vector2 GravityDefault => gravityDefault;
	public float GravityMultiplier => gravityMultiplier;
	public float JumpForce => jumpForce;
	public int NumJumps => numJumps;
	public int NumSeeds => numSeeds;
	public float MaxWaterLevel => maxWaterLevel;

}
