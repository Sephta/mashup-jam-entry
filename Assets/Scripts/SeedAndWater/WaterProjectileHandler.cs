using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class WaterProjectileHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private Lean.Pool.LeanGameObjectPool leanPool = null;
	[SerializeField] private GameObject waterParticleSystem = null;
	[SerializeField] private float particleSystemDestroyTime = 1f;
	[SerializeField, Required] private GameObject plantSegmentPrefab = null;
	[SerializeField, ReadOnly] private Transform plantGrowthParent = null;

	[SerializeField, Tag, Required] private string tagToDetect;
	[SerializeField] private float _deathTime = 0f;
	[SerializeField, ReadOnly] private float currDeathTimer = 0f;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

    void Start()
	{
		leanPool = GameObject.FindObjectOfType<Lean.Pool.LeanGameObjectPool>();
		plantGrowthParent = GameObject.Find("~PlantGrowthParent").transform;

		currDeathTimer = _deathTime;
	}

    void Update()
	{
		UpdateDeathTimer();

		CheckDeathTimer();
	}

	// void FixedUpdate() {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag(tagToDetect))
		{
			InstantiatePlantGrowthSegment();
			DestroySelf(InstaniateParticles: true);
		}
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InstantiatePlantGrowthSegment()
	{
		if (plantSegmentPrefab == null) return;

		// GameObject refr = Instantiate(plantSegmentPrefab, this.transform.position, Quaternion.identity);
		leanPool.Spawn(this.transform.position, Quaternion.identity, plantGrowthParent);
	}

	private void DestroySelf(bool InstaniateParticles = false)
	{
		if (InstaniateParticles) SpawnWaterParticles();

		Destroy(this.gameObject);
	}

	private void SpawnWaterParticles()
	{
		if (waterParticleSystem == null) return;

		GameObject refr = Instantiate(waterParticleSystem, this.transform.position, Quaternion.identity);

		Destroy(refr, particleSystemDestroyTime);
	}

	private void UpdateDeathTimer()
		=> currDeathTimer = Mathf.Clamp((currDeathTimer - Time.deltaTime), 0f, _deathTime);

	private void CheckDeathTimer()
	{
		if (currDeathTimer <= 0f)
			DestroySelf();
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
