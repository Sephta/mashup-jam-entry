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
	[SerializeField] private LayerMask rayCastMask;
	[SerializeField] private float rayCastDistance = 1f;
	[SerializeField, ReadOnly] private bool castCheck = false;

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
		UI_WaterDisplayHandler.GenerateWaterUI?.Invoke((int) _playerStats.MaxWaterLevel);
		ResetWaterTickTime();

		currSeedCount = _playerStats.NumSeeds;
		UI_SeedDisplayHandler.GenerateSeedUI?.Invoke(_playerStats.NumSeeds);
	}

	private bool PressingActionKeys => Input.GetKey(iManager._keyBindings[InputAction.action01]) ||
										  Input.GetKey(iManager._keyBindings[InputAction.action02]);
    void Update()
	{
		castCheck = PlantsTooClose;

		UpdateWaterTickTime();
	
		if (Input.GetKey(iManager._keyBindings[InputAction.action01]) && currSeedCount > 0)
		{
			FlipSpriteHandler.ToggleHeldItemVisuals?.Invoke(true);
			FlipSpriteHandler.ChangeHeldItemSprite?.Invoke(_playerStats.SeedBag);
		}
		
		if (!PressingActionKeys)
			FlipSpriteHandler.ToggleHeldItemVisuals?.Invoke(false);

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

	private bool PlayerCanFireSeed => (Input.GetKeyUp(iManager._keyBindings[InputAction.action01]) && (currSeedCount > 0));
	private bool PlantsTooClose
		=> Physics2D.Raycast(this.transform.position, GetLaunchDirection(), rayCastDistance, rayCastMask);

	private void CheckToFireSeed()
	{
		if (iManager == null) return;

		if (PlayerCanFireSeed)
		{
			LaunchProjectile(_playerStats.SeedPrefab, _playerStats.SeedLaunchForce);
			UpdateSeedCount(-1f);
			UI_SeedDisplayHandler.UpdateSeedUI?.Invoke(currSeedCount);
		}
	}

	private bool PlayerCanFireWater => (Input.GetKey(iManager._keyBindings[InputAction.action02]) && (currWaterTickTime <= 0));
	private bool PlayerHasWaterToFire => (currWaterLevel > 0);
	private void CheckToFireWater()
	{
		if (iManager == null) return;

		if (PlayerCanFireWater && PlayerHasWaterToFire && !PlantsTooClose)
		{
			FlipSpriteHandler.ToggleHeldItemVisuals?.Invoke(true);
			FlipSpriteHandler.ChangeHeldItemSprite?.Invoke(_playerStats.WaterCan);

			LaunchProjectile(_playerStats.WaterPrefab, _playerStats.WaterLaunchForce);
			ResetWaterTickTime();
			UpdateWaterLevel(-1f);
			UI_WaterDisplayHandler.UpdateWaterUI?.Invoke((int) currWaterLevel);
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
