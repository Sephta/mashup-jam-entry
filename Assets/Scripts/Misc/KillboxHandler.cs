using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using NaughtyAttributes;


public class KillboxHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Scene] private string SceneToReload = "";
	[SerializeField, Tag] private string tagToDetect;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}
    // void Start() {}
    // void Update() {}
	// void FixedUpdate() {}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag(tagToDetect))
			ReloadScene();
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void ReloadScene()
	{
		Scene sceneCheck = SceneManager.GetActiveScene();
		if (sceneCheck.name == SceneToReload)
			SceneManager.LoadScene(SceneToReload);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
