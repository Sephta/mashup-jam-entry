using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(UIComponent))]
public class LTUI_Value : TweenWrapperComponent
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private LeanTweenValueSettingsSO _tweenSettings;

	[Space(25)] public UnityEvent OnCompleteAction;
	[SerializeField] private UIComponent _componentMaster = null;

	[SerializeField] private TextMeshProUGUI _valueText = null;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		_componentMaster = GetComponent<UIComponent>();

		_valueText = GetComponent<TextMeshProUGUI>();
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

	private void UpdateValueText (float val) => _valueText.text = val.ToString("F1");

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */
	public override void TweenTo()
	{

	}

	public override void TweenTo(bool useRectTransform = true)
	{
		if (_tweenSettings == null)
		{
			Debug.LogWarning("[WARNING] LeanTweenValueSettingsSO, '_tweenSettings', on " + this.gameObject.name + " is null.");
			return;
		}

		LeanTween.value(this.gameObject, _tweenSettings.ScaleFrom, _tweenSettings.ScaleTo, _tweenSettings.TimeToTween)
			.setDelay(_tweenSettings.EnableDelayTime)
			.setEase(_tweenSettings.EaseType)
			.setOnComplete(LTSettingsOnCompleteEventInvoke)
			.setOnUpdate(UpdateValueText);
	}

	public override void TweenBack(bool shouldDisableObject = false)
	{
		if (_tweenSettings == null)
		{
			Debug.LogWarning("[WARNING] LeanTweenValueSettingsSO, '_tweenSettings', on " + this.gameObject.name + " is null.");
			return;
		}

		if (shouldDisableObject)
		{
			LeanTween.value(this.gameObject, _tweenSettings.ScaleTo, _tweenSettings.ScaleFrom, _tweenSettings.TimeToTween)
				.setDelay(_tweenSettings.DisableDelayTime)
				.setEase(_tweenSettings.EaseType)
				.setOnUpdate(UpdateValueText)
				.setOnComplete(SetActiveOff);
		}
		else
		{
			LeanTween.value(this.gameObject, _tweenSettings.ScaleTo, _tweenSettings.ScaleFrom, _tweenSettings.TimeToTween)
				.setDelay(_tweenSettings.DisableDelayTime)
				.setEase(_tweenSettings.EaseType)
				.setOnUpdate(UpdateValueText);
		}
	}

}
