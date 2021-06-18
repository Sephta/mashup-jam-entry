using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New LeanTween Settings", menuName = "LeanTweenSettings/ScaleSettings", order = 2)]
public class LeanTweenScaleSettingsSO : LeanTweenSettingsSO
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[Header("Scale Settings")]
	[SerializeField] private Vector3 _scaleValue     = Vector3.zero;

	public Vector3 ScaleValue     => _scaleValue;

	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
