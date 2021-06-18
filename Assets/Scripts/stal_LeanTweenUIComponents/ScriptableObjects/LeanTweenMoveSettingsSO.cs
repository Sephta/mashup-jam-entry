using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New LeanTween Settings", menuName = "LeanTweenSettings/MoveSettings", order = 1)]
public class LeanTweenMoveSettingsSO : LeanTweenSettingsSO
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[Header("Move Settings")]
	[SerializeField] private Vector3 _movePosition   = Vector3.zero;

	public Vector3 MovePosition   => _movePosition;

	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
