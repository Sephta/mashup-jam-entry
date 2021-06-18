using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(UIComponent))]
public class LTUI_Move : TweenWrapperComponent
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private LeanTweenMoveSettingsSO _tweenSettings;

	[Space(25)] public UnityEvent OnCompleteAction;
	[SerializeField] private UIComponent _componentMaster = null;

	[SerializeField] private Vector3 _cachedStartPosition = Vector3.zero;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		_componentMaster = GetComponent<UIComponent>();

		_cachedStartPosition = _rectTransform.localPosition;
	}

    // void Start() {}
    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	protected override void LTSettingsOnCompleteEventInvoke() => OnCompleteAction?.Invoke();

	// Modify Active State of GameObject ---------------------------------
	private void SetActiveState(bool s) => gameObject.SetActive(s);
	private void SetActiveOff() => gameObject.SetActive(false);
	private void SetActiveOn() => gameObject.SetActive(true);
	// -------------------------------------------------------------------

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */
	public override void TweenTo()
	{
		if (_tweenSettings == null)
		{
			Debug.LogWarning("[WARNING] LeanTweenMoveSettingsSO, '_tweenSettings', on " + this.gameObject.name + " is null.");
			return;
		}

		LeanTween.move(_rectTransform, _cachedStartPosition + _tweenSettings.MovePosition, _tweenSettings.TimeToTween)
			.setDelay(_tweenSettings.EnableDelayTime)
			.setEase(_tweenSettings.EaseType)
			.setOnComplete(LTSettingsOnCompleteEventInvoke);
	}

	public override void TweenBack(bool shouldDisableObject = false)
	{
		if (_tweenSettings == null)
		{
			Debug.LogWarning("[WARNING] LeanTweenMoveSettingsSO, '_tweenSettings', on " + this.gameObject.name + " is null.");
			return;
		}

		if (shouldDisableObject)
		{
			LeanTween.move(_rectTransform, _cachedStartPosition, _tweenSettings.TimeToTween)
				.setDelay(_tweenSettings.DisableDelayTime)
				.setEase(_tweenSettings.EaseType)
				.setOnComplete(SetActiveOff);
		}
		else
		{
			LeanTween.move(_rectTransform, _cachedStartPosition, _tweenSettings.TimeToTween)
				.setDelay(_tweenSettings.DisableDelayTime)
				.setEase(_tweenSettings.EaseType);
		}
	}

}
