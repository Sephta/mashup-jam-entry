using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using NaughtyAttributes;


public class UI_SeedDisplayHandler : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField] private GameObject _UISeedPrefab = null;
	[SerializeField] private List<GameObject> _seeds = new List<GameObject>();

	public static UnityAction<int> GenerateSeedUI;
	public static UnityAction<int> UpdateSeedUI;

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	// void Awake() {}

	void OnEnable()
	{
		GenerateSeedUI += InitSeedUI;
		UpdateSeedUI += RefreshSeedUI;
	}

	void OnDisable()
	{
		GenerateSeedUI -= InitSeedUI;
		UpdateSeedUI -= RefreshSeedUI;
	}

    // void Start() {}
    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */
	private void InitSeedUI(int numSeeds)
	{
		for (int i = 0; i < numSeeds; i++)
		{
			GameObject refr = Instantiate(_UISeedPrefab, this.transform.position, Quaternion.identity, this.transform);
			_seeds.Add(refr);
		}
	}

	private void RefreshSeedUI(int delta)
	{
		Image seedImage = _seeds[delta].GetComponent<Image>();
		seedImage.color = new Color(seedImage.color.r,
									seedImage.color.g,
									seedImage.color.b,
									0.25f);
	}


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
