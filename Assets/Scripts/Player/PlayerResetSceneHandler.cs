using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using NaughtyAttributes;


public class PlayerResetSceneHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Scene] private string SceneToReload = "";

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}
    // void Start() {}

    void Update()
	{
		CheckIfResetPressed();
	}

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private bool PlayerPressedReset => (Input.GetKeyDown(InputManager._inst._keyBindings[InputAction.restart]));
	private void CheckIfResetPressed()
	{
		if (PlayerPressedReset)
		{
			Scene sceneCheck = SceneManager.GetActiveScene();
			if (sceneCheck.name == SceneToReload)
				SceneManager.LoadScene(SceneToReload);
		}
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
