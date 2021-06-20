using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class SeedProjectileHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Required] private GameObject plantGrowthPrefab = null;
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
		currDeathTimer = _deathTime;

		plantGrowthParent = GameObject.Find("~PlantGrowthParent").transform;
	}

    void Update()
	{
		UpdateDeathTimer();

		CheckDeathTimer();
	}

	// void FixedUpdate() {}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag(tagToDetect))
		{
			InstantiatePlantGrowthController();
			DestroySelf();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag(tagToDetect))
		{
			InstantiatePlantGrowthController();
			DestroySelf();
		}
	}
	// void OnTriggerStay2D(Collider2D other) {}
	// void OnTriggerExit2D(Collider2D other) {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InstantiatePlantGrowthController()
	{
		if (plantGrowthPrefab == null) return;

		GameObject refr = (plantGrowthParent == null) ? 
			Instantiate(plantGrowthPrefab, transform.position, Quaternion.identity)
			: Instantiate(plantGrowthPrefab, transform.position, Quaternion.identity, plantGrowthParent);
	}	

	private void DestroySelf() => Destroy(this.gameObject);

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
