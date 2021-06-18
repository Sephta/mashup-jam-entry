using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TweenWrapperComponent : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] protected RectTransform _rectTransform = null;

	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	protected abstract void LTSettingsOnCompleteEventInvoke();

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

	public abstract void TweenTo();
	public abstract void TweenBack(bool shouldDisableObject = false);

}
