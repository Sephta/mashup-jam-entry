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
	[SerializeField, Range(0f, 25f)] private int numSegmentsToSpwan = 0;
	[SerializeField, ReadOnly] private int segmentsLeftToSpawn = 0;
	[SerializeField, Range(0f, 0.5f)] private float growthTickRate = 0f;
	[SerializeField, ReadOnly] private float currTickTime = 0f;
	[SerializeField, MinMaxSlider(-1f, 1f)] private Vector2 newSegmentSpawnOffset = Vector2.zero;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

    void Start()
	{
		InitializePlantGrowthController();

		currTickTime = growthTickRate;
		segmentsLeftToSpawn = numSegmentsToSpwan;
	}

    void Update()
	{
		UpdateTickTimer();

		if (currTickTime <= 0f && segmentsLeftToSpawn > 0)
		{
			SpawnNewPlantSegment();

			segmentsLeftToSpawn = (int) Mathf.Clamp(segmentsLeftToSpawn - 1, 0f, numSegmentsToSpwan);
		}
	}

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void UpdateTickTimer() => currTickTime = Mathf.Clamp((currTickTime - Time.deltaTime), 0f, growthTickRate);

	private void InitializePlantGrowthController()
	{
		if (plantSegment == null) return;

		SpawnInitialPlantSegment();
	}

	private void SpawnInitialPlantSegment()
	{
		GameObject refr = Instantiate(plantSegment, this.transform.position, Quaternion.identity, this.transform);
	}

	private void SpawnNewPlantSegment()
	{
		float xPosOffset = Random.Range(newSegmentSpawnOffset.x, newSegmentSpawnOffset.y);
		float yPosOffset = Random.Range(newSegmentSpawnOffset.x, newSegmentSpawnOffset.y);
		
		GameObject refr = Instantiate(plantSegment,
									  this.transform.position + new Vector3(xPosOffset, yPosOffset, 0f),
									  Quaternion.identity,
									  this.transform);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
