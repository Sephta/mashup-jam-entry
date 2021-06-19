using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenInitializer : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private int _maxSimultaneousTweens = 0;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}
    void Start()
	{
		LeanTween.init(maxSimultaneousTweens: _maxSimultaneousTweens);
	}
    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
