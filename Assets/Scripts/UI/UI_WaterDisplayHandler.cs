using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using NaughtyAttributes;

public class UI_WaterDisplayHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private Image _fill = null;

	[Header("Progress Bar Settings")]
	[SerializeField] private float max = 0f;
    [SerializeField] private float current = 0f;

	public static UnityAction<int> GenerateWaterUI;
	public static UnityAction<int> UpdateWaterUI;


	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

	void OnEnable()
	{
		GenerateWaterUI += InitWaterUI;
		UpdateWaterUI += RefreshWaterUI;
	}

	void OnDisable()
	{
		GenerateWaterUI -= InitWaterUI;
		UpdateWaterUI -= RefreshWaterUI;
	}

    // void Start() {}

    void Update()
    {
        GetFillAmount();
    }

    void GetFillAmount()
    {
        float fill = current / max;

        _fill.fillAmount = fill;
    }

	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InitWaterUI(int amount) => current = max = amount;

	private void RefreshWaterUI(int amount) => current = amount;

	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
