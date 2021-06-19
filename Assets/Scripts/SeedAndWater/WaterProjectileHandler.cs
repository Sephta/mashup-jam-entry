using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class WaterProjectileHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private GameObject waterParticleSystem = null;

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
			// InstantiatePlantGrowthController();
			DestroySelf(InstaniateParticles: false);
		}
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void DestroySelf(bool InstaniateParticles = false)
	{
		if (InstaniateParticles) SpawnWaterParticles();

		Destroy(this.gameObject);
	}

	private void SpawnWaterParticles()
	{
		if (waterParticleSystem == null) return;

		GameObject refr = Instantiate(waterParticleSystem, this.transform.position, Quaternion.identity);
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
