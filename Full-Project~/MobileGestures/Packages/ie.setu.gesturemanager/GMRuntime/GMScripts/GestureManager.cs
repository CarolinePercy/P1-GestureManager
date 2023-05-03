using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class SwipeEvent : UnityEvent<Vector2> { }

[System.Serializable]
public class TapEvent : UnityEvent<Vector2> { }


public class GestureManager : MonoBehaviour
{

    [Header("Settings")]
    [Range(0.1f, 20.0f)]
    [Tooltip("This controls how much the input must move before a 'Press' turns into a 'Swipe'.")]
    public float swipeSensitivity = 6;

    [Range(0.0f, 3.0f)]
    [Tooltip("This controls how long before a 'Tap' turns into a 'Press'.")]
    public float maxTapDuration = 0.2f;

    [Range(0.0f, 3.0f)]
    //[Tooltip("This controls how long before a 'Tap' turns into a 'Press'.")]
    public float HoldDuration = 0.4f;

    [Header("Events")]
    public TapEvent Tap;
    public SwipeEvent Swipe;

    private Vector2 startScreenTouchPosition;
    private Vector2 currentScreenTouchPosition;

    PlayerInput playerIn;

    private void OnMove(InputValue value)
    {
        currentScreenTouchPosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnTap()
    {
        Tap.Invoke(currentScreenTouchPosition);
    }

    private void OnSwipe(InputValue value)
    {
        Vector2 change = value.Get<Vector2>();

        if (Mathf.Abs(change.x) > swipeSensitivity || Mathf.Abs(change.y) > swipeSensitivity)
        {
            Swipe.Invoke(change);
        }

    }

    void Reset()
    {
        AddPlayerInput();
    }

    private void OnValidate()
    {
        AddPlayerInput();

        InputActionMap gestures = playerIn.actions.FindActionMap("GestureControls");

        gestures.FindAction("Tap").ApplyParameterOverride("duration", maxTapDuration);
    }

    private void AddPlayerInput()
    {
        if (playerIn == null)
        {
            if (GetComponent<PlayerInput>() == null)
            {
                playerIn = gameObject.AddComponent<PlayerInput>();
                playerIn.camera = Camera.main;
            }

            else
            {
                playerIn = GetComponent<PlayerInput>();
            }
        }


        AddActions();
    }

    private void AddActions()
    {
        if (playerIn.actions == null)
        {
            InputActionAsset actions = (InputActionAsset)AssetDatabase.LoadAssetAtPath("Packages/ie.setu.gesturemanager/GMRuntime/GestureManagerControls.inputactions", typeof(InputActionAsset));

            playerIn.actions = actions;
        }
    }
}
