using System.Collections.Generic;
using UnityEngine;


#region Input Action
// Instead of strings, the keybindings will use a public enum to describe
// each input action in both "written" and numeric form
public enum InputAction
{
    moveUp    = 0,
    moveDown  = 1,
    moveLeft  = 2,
    moveRight = 3,
    run       = 4,
    jump      = 5,
    attack    = 6,
    nextItem  = 7,
    prevItem  = 8,
    pause     = 9,
    action01  = 10,
    action02  = 11,
    restart   = 12
}

#endregion

#region Keybind Immutable Container
// This is a hack-y sort of way to make it simple to manually input defined keybindings
// from the inspector. This struct is an object that simply stores an InputAction and a
// corresponding KeyCode for the action to be bound to.
[System.Serializable] // This allows the struct to be serializable/visible within the Unity inspector window
public struct Keybind
{
    public InputAction action;
    public KeyCode key;
}
#endregion


public class InputManager : MonoBehaviour
{

#region Singleton Instance Member
    [Tooltip("This singleton reference for the input manager.")]
    public static InputManager _inst;
#endregion

    [Header("Keybind Data")]
    
    [Tooltip("Lets the InputManager know if you want to manually initialize new actions into the keyBindings dict.")]
    public bool manualInput = false;
    
    [Tooltip("Number of actions.")]
    public int numActions = 0;

    [Tooltip("Manually Input Keybindings here.")]
    [SerializeField] public List<Keybind> _keyBindings_test = new List<Keybind>();

    // This dictionary is where the actual bindings should be accessed
    public Dictionary<InputAction, KeyCode> _keyBindings = new Dictionary<InputAction, KeyCode>();

    [Header("Input Data")]
    [SerializeField] private bool trackMovement = true;
    public Vector2 prevDirection = Vector2.zero;
    public Vector2 direction = Vector2.zero;

#region Unity Functions
    void Awake()
    {
        // Confirm singleton instance is active
        if (_inst == null)
        {
            _inst = this;
            DontDestroyOnLoad(this);
        }
        else if (_inst != this)
            GameObject.Destroy(this.gameObject);
    }

    void Start()
    {
        // manually feed each input into the dict
        if (manualInput == true)
        {
            foreach (Keybind input in _keyBindings_test)
                _keyBindings.Add(input.action, input.key);
        }
    }

    void Update()
    {
        if (trackMovement)
            UpdateDirectionVector();
    }

    // void FixedUpdate() {}
#endregion

/// <summary>
    /// Finds and normalizes input direction using custom InputManager system
    /// </summary>
    private void UpdateDirectionVector()
    {
        if (InputManager._inst == null)
            return;
        
        prevDirection = direction;
        
        InputManager iManager = InputManager._inst;

        if (Input.GetKey(iManager._keyBindings[InputAction.moveUp]))
            direction.y = 1.0f;
        else if (Input.GetKey(iManager._keyBindings[InputAction.moveDown]))
            direction.y = -1.0f;
        else
            direction.y = 0;
        if (Input.GetKey(iManager._keyBindings[InputAction.moveLeft]))
            direction.x = -1.0f;
        else if (Input.GetKey(iManager._keyBindings[InputAction.moveRight]))
            direction.x = 1.0f;
        else
            direction.x = 0;
        
        // direction = direction.normalized;
    }
}