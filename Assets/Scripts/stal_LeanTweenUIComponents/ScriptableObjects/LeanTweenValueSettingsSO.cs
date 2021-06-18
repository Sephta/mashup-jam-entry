using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New LeanTween Settings", menuName = "LeanTweenSettings/ValueSettings", order = 3)]
public class LeanTweenValueSettingsSO : LeanTweenSettingsSO
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[Header("Value Settings")]
	[SerializeField] private float _scaleFrom        = 0f;
	[SerializeField] private float _scaleTo          = 0f;

	public float ScaleFrom        => _scaleFrom;
	public float ScaleTo          => _scaleTo;

	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
