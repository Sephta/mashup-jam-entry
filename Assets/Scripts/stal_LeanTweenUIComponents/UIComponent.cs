using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComponent : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[Tooltip("The starting active state when entering playmode.")]
	[SerializeField] private bool _startState = false;
	
	[Tooltip("Sets the active state to false when tweening back to default state.")]
	[SerializeField] private bool _objectShouldDisableOnReset = true;

	[SerializeField] private List<TweenWrapperComponent> _tweens = new List<TweenWrapperComponent>();

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		PreprocessTweenComponents();
		SetActiveState(_startState);
	}

    // void Start() {}
    // void Update() {}
	// void FixedUpdate() {}
#endregion

	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void PreprocessTweenComponents()
	{
		var tweens = GetComponents<TweenWrapperComponent>();

		foreach (var tween in tweens)
			_tweens.Add(tween);
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */
	public void SetActiveState(bool s) => gameObject.SetActive(s);

	public void ToggleTweens()
	{
		if (gameObject.activeSelf == true && !LeanTween.isTweening(this.gameObject))
		{
			TweenToEndState();
		}
		else if (!gameObject.activeSelf && !LeanTween.isTweening(this.gameObject))
		{
			TweenToStartState();
		}
	}
	
	public void TweenToStartState()
	{
		foreach (var tweener in _tweens)
		{
			SetActiveState(true);
			tweener.TweenTo();
		}
	}
	
	public void TweenToEndState()
	{
		foreach (var tweener in _tweens)
		{
			tweener.TweenBack(_objectShouldDisableOnReset);
		}
	}

}
