using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using NaughtyAttributes;


public class FlagEndGoalHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Scene] private string SceneToLoad = "";
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
			LoadNextScene(SceneToLoad);
	}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void LoadNextScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
