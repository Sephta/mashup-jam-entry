using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


[RequireComponent(typeof(SpriteRenderer))]
public class SetRandomPlantSprite : MonoBehaviour
{
	/* ---------------------------------------------------------------- */
	/*                          Class Variables                         */
	/* ---------------------------------------------------------------- */
	[SerializeField, Required] private SpriteRenderer _sr = null;
	[SerializeField] private List<Sprite> plantSprites = new List<Sprite>();

	/* ---------------------------------------------------------------- */
	/*                           Unity Methods                          */
	/* ---------------------------------------------------------------- */

#region Unity_Monobehavior_Methods
	void Awake()
	{
		if (_sr == null)
			_sr = GetComponent<SpriteRenderer>();
	}

    void Start()
	{
		_sr.sprite = plantSprites[(int) Random.Range(0f, (float) plantSprites.Count)];
	}

    // void Update() {}
	// void FixedUpdate() {}
#endregion


	/* ---------------------------------------------------------------- */
	/*                          Private Methods                         */
	/* ---------------------------------------------------------------- */


	/* ---------------------------------------------------------------- */
	/*                           Public Methods                         */
	/* ---------------------------------------------------------------- */

}
