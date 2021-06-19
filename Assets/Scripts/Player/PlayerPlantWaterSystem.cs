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
	[SerializeField, Required] private GameObject seedProjectile = null;
	[SerializeField, Required] private Transform launchPoint = null;

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
	}

    void Update()
	{
		CheckToFireSeed();
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

	private void CheckToFireSeed()
	{
		if (iManager == null) return;

		if (Input.GetKeyDown(iManager._keyBindings[InputAction.action01]))
		{
			LaunchSeed();
		}
	}

	private void LaunchSeed()
	{
		GameObject refr = Instantiate(seedProjectile, launchPoint.position, Quaternion.identity);

		Rigidbody2D refrRB = refr.GetComponent<Rigidbody2D>();

		refrRB.AddForce(GetLaunchDirection() * _playerStats.LaunchForce, ForceMode2D.Impulse);
	}

	private Vector3 GetLaunchDirection()
	{
		return (launchPoint.position - transform.position).normalized;
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
