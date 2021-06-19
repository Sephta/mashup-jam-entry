using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class PlantSegmentHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Required] private GameObject plantSegmentSpritePrefab = null;
	[SerializeField, Range(0f, 10f)] private int numPlantSprites = 0;
	[SerializeField, MinMaxSlider(-180f, 180f)] private Vector2 rotationRange = Vector2.zero;
	[SerializeField, MinMaxSlider(-1f, 1f)] private Vector2 offsetRange = Vector2.zero;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

    void Start()
	{
		InitializePlantSegment();
	}

    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InitializePlantSegment()
	{
		if (plantSegmentSpritePrefab == null) return;

		for (int i = 0; i < numPlantSprites; i++)
		{
			SpawnPlantSegmentSprites();	
		}
	}

	private void SpawnPlantSegmentSprites()
	{
		float randomXPos = Random.Range(offsetRange.x, offsetRange.y);
		float randomYPos = Random.Range(offsetRange.x, offsetRange.y);

		float randomRot = Random.Range(rotationRange.x, rotationRange.y);

		GameObject refr = Instantiate(plantSegmentSpritePrefab, 
									  this.transform.position + new Vector3(randomXPos, randomYPos, 0f),
									  Quaternion.Euler(0f, 0f, randomRot),
									  this.transform);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
