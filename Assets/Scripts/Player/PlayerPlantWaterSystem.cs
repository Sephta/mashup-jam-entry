using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


public class PlayerPlantWaterSystem : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Expandable, Required] private PlayerStatsSO _playerStats = null;

	// For use with the ProgressBar NaughtyAttribute
	private float mwl => _playerStats.MaxWaterLevel;

	[Space(25)]
	[Header("Water Configurables")]
	[ProgressBar("Current Water Level", "mwl", EColor.Blue), Space]
	public float currWaterLevel = 0;
	[SerializeField, ReadOnly] private float currWaterTickTime = 0f;

	[Space(10)]
	[Header("Seed Configurables")]
	[SerializeField, Required] private Transform launchPoint = null;
	[SerializeField, ReadOnly] private int currSeedCount = 0;
	[Space(25)]

	[SerializeField, ReadOnly] private InputManager iManager = null;

	// Caching the main camera cuz I'm not sure if unity fixed "Camera.main"
	// and made it more efficient....
	private Camera playerCam = null;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		if (Camera.main != null)
			playerCam = Camera.main;
	}

    void Start()
	{
		if (InputManager._inst != null)
			iManager = InputManager._inst;

		currWaterLevel = _playerStats.MaxWaterLevel;
		ResetWaterTickTime();
		currSeedCount = _playerStats.NumSeeds;
	}

    void Update()
	{
		UpdateWaterTickTime();
	
		CheckToFireSeed();
		CheckToFireWater();
	}

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private Vector3 GetWorldSpaceMousePosition()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private Vector3 GetLaunchDirection()
	{
		return (launchPoint.position - transform.position).normalized;
	}

	private void LaunchProjectile(GameObject projectile, float forceToAdd)
	{
		GameObject refr = Instantiate(projectile, launchPoint.position, Quaternion.identity);

		Rigidbody2D refrRB = refr.GetComponent<Rigidbody2D>();

		refrRB.AddForce(GetLaunchDirection() * forceToAdd, ForceMode2D.Impulse);
	}

	private bool PlayerCanFireSeed => (Input.GetKeyDown(iManager._keyBindings[InputAction.action01]) && (currSeedCount > 0));
	private void CheckToFireSeed()
	{
		if (iManager == null) return;

		if (PlayerCanFireSeed)
		{
			LaunchProjectile(_playerStats.SeedPrefab, _playerStats.SeedLaunchForce);
			UpdateSeedCount(-1f);
		}
	}

	private bool PlayerCanFireWater => (Input.GetKey(iManager._keyBindings[InputAction.action02]) && (currWaterTickTime <= 0));
	private bool PlayerHasWaterToFire => (currWaterLevel > 0);
	private void CheckToFireWater()
	{
		if (iManager == null) return;

		if (PlayerCanFireWater && PlayerHasWaterToFire)
		{
			LaunchProjectile(_playerStats.WaterPrefab, _playerStats.WaterLaunchForce);
			ResetWaterTickTime();
			UpdateWaterLevel(-1f);
		}
	}

	private void UpdateWaterLevel(float delta)
		=> currWaterLevel = Mathf.Clamp((currWaterLevel + delta), 0f, _playerStats.MaxWaterLevel);
	
	private void UpdateSeedCount(float delta)
		=> currSeedCount = (int) Mathf.Clamp((currSeedCount + delta), 0, _playerStats.NumSeeds);

	private void ResetWaterTickTime() => currWaterTickTime = _playerStats.WaterLaunchRate;
	private void UpdateWaterTickTime()
		=> currWaterTickTime = Mathf.Clamp((currWaterTickTime - Time.deltaTime), 0f, _playerStats.WaterLaunchRate);

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
