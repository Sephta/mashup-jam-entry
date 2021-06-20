using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using NaughtyAttributes;


// [RequireComponent(typeof(SpriteRenderer))]
public class FlipSpriteHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Required] private SpriteRenderer _sr = null;
	[SerializeField, Required] private Transform _relativePoint = null;
	[SerializeField] private Vector2 flipAxis = Vector2.zero;
	[SerializeField] private float tweenTime = 0f;
	[SerializeField] private LeanTweenType easeType;

	public static UnityAction<bool> ToggleHeldItemVisuals;
	public static UnityAction<Sprite> ChangeHeldItemSprite;

	[SerializeField, ReadOnly] private InputManager iManager = null;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		// if (_sr == null)
		// 	_sr = GetComponent<SpriteRenderer>();	
	}

	void OnEnable()
	{
		ToggleHeldItemVisuals += TweenToggleHeldItem;
		// ToggleHeldItemVisuals += ToggleHeldItem;
		ChangeHeldItemSprite  += UpdateSprite;
	}

	void OnDisable()
	{
		ToggleHeldItemVisuals -= TweenToggleHeldItem;
		// ToggleHeldItemVisuals -= ToggleHeldItem;
		ChangeHeldItemSprite  -= UpdateSprite;
	}

    void Start()
	{
		if (InputManager._inst != null)
            iManager = InputManager._inst;
	}

    void Update()
	{
		UpdateSpriteFlipDirection();
	}

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private Vector3 GetRelativeDirection()
	{
		return (_relativePoint.position - this.transform.position).normalized;
	}

	private void UpdateSpriteFlipDirection()
	{
		Vector3 dir = GetRelativeDirection();

		if (flipAxis.x != 0)
		{
			if (dir.x > 0)
            	_sr.flipX = false;
        	else if (dir.x < 0)
            	_sr.flipX = true;
		}

		if (flipAxis.y != 0)
		{
			if (dir.x > 0)
            	_sr.flipY = false;
        	else if (dir.x < 0)
            	_sr.flipY = true;
		}
	}

	private void SetEnabledTrue() => _sr.enabled = true;
	private void SetEnabledFalse() => _sr.enabled = false;

	private void TweenToggleHeldItem(bool state)
	{
		if (LeanTween.isTweening(_sr.gameObject)) return;

		if (state)
		{
			LeanTween.scale(_sr.gameObject, Vector3.one, tweenTime)
				.setEase(easeType)
				.setOnStart(SetEnabledTrue);
		}
		else
		{
			LeanTween.scale(_sr.gameObject, Vector3.zero, tweenTime)
				.setEase(easeType)
				.setOnComplete(SetEnabledFalse);
		}
	}

	private void ToggleHeldItem(bool state)
	{
		if (_sr == null) return;

		_sr.enabled = state;
	}

	private void UpdateSprite(Sprite spriteToSet)
	{
		if (_sr == null) return;

		_sr.sprite = spriteToSet;
	}

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
