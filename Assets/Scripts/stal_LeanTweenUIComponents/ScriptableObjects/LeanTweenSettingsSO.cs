using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TweenType
{
	move = 0,
	value = 1,
	scale = 2
}

public class LeanTweenSettingsSO : ScriptableObject
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[Header("General Tween Settings")]
	[SerializeField] private TweenType _tweenType;
	[SerializeField] private float _timeToTween      = 0f;
	[SerializeField] private LeanTweenType _easeType;
	[SerializeField] private float _enableDelayTime  = 0f;
	[SerializeField] private float _disableDelayTime = 0f;
	// [SerializeField] private Vector3 _movePosition   = Vector3.zero;
	// [SerializeField] private Vector3 _scaleValue     = Vector3.zero;
	// [SerializeField] private float _scaleFrom        = 0f;
	// [SerializeField] private float _scaleTo          = 0f;


	public TweenType Type         => _tweenType;
	public float TimeToTween      => _timeToTween;
	public LeanTweenType EaseType => _easeType;
	public float EnableDelayTime  => _enableDelayTime;
	public float DisableDelayTime => _disableDelayTime;
	// public Vector3 MovePosition   => _movePosition;
	// public Vector3 ScaleValue     => _scaleValue;
	// public float ScaleFrom        => _scaleFrom;
	// public float ScaleTo          => _scaleTo;


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
