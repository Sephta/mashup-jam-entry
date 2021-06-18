using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;


[RequireComponent(typeof(SpriteRenderer))]
public class FlipPlayerSprite : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer _sr = null;
    [SerializeField] private Rigidbody2D _parentRB = null;

    [SerializeField, ReadOnly] private InputManager iManager = null;

    private void Awake()
    {
        if (_sr == null && GetComponent<SpriteRenderer>() != null)
            _sr = GetComponent<SpriteRenderer>();
        
        if (_parentRB == null)
            _parentRB = GetComponentInParent<Rigidbody2D>();
    }

    private void Start()
    {
        if (InputManager._inst != null)
            iManager = InputManager._inst;
    }

    private void Update()
    {    
        FlipSprite();
    }

    private void FlipSprite()
    {

        if (iManager.direction.x > 0)
            _sr.flipX = false;
        else if (iManager.direction.x < 0)
            _sr.flipX = true;
    }
}
