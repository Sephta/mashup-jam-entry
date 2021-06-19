using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Growth Stats Asset", menuName = "ScriptableObjects/PlantGrowthStats", order = 1)]
public class PlantGrowthStatsSO : ScriptableObject
{
	/* ---------------------------------------------------------------- */
	/*                          Configurable Stats                      */
	/* ---------------------------------------------------------------- */
	[SerializeField] private float plantGrowthRate = 0f;

	/* ---------------------------------------------------------------- */
	/*                           Lambda Getters                         */
	/* ---------------------------------------------------------------- */
	public float PlantGrowthRate => plantGrowthRate;

}
