using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class PlantGrowthController : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Expandable, Required] private PlantGrowthStatsSO _pls = null;
	[SerializeField, Required] private GameObject plantSegment = null;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

    void Start()
	{
		InitializePlantGrowthController();
	}

    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InitializePlantGrowthController()
	{
		if (plantSegment == null) return;

		SpawnInitialPlantSegment();
	}

	private void SpawnInitialPlantSegment()
	{
		GameObject refr = Instantiate(plantSegment, this.transform.position, Quaternion.identity, this.transform);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
