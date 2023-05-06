using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class SwipeEvent : UnityEvent<Vector2> { }

[System.Serializable]
public class TapEvent : UnityEvent<Vector2> { }

[System.Serializable]
public class PressEvent : UnityEvent<Vector2> { }

[System.Serializable]
public class PinchEvent : UnityEvent<float> { }


public class GestureManager : MonoBehaviour
{

    [Header("Settings")]
    [Range(0.1f, 20.0f)]
    [Tooltip("This controls how much the input must move before a 'Press' turns into a 'Swipe'.")]
    public float swipeSensitivity = 6;

    [Range(0.01f, 10.0f)]
    [Tooltip("This controls how much the input must move before a 'Press' turns into a 'Swipe'.")]
    public float swipeSpeed = 1.0f;

    [Range(0.0f, 3.0f)]
    [Tooltip("This controls how long before a 'Tap' turns into a 'Press'.")]
    public float maxTapDuration = 0.2f;

    [Range(0.01f, 2.0f)]
    //[Tooltip("This controls how long before a 'Tap' turns into a 'Press'.")]
    public float holdMovement = 1.0f;

    [Header("Events")]
    public TapEvent Tap;
    public SwipeEvent Swipe;
    public PressEvent Press;
    public PinchEvent Pinch;

    private Vector2 startScreenTouchPosition = new Vector2();
    private Vector2 currentScreenTouchPosition = new Vector2();
    private Vector2 secondFingerPosition = new Vector2();   

    PlayerInput playerIn;

    private void OnMove(InputValue value)
    {
        startScreenTouchPosition = currentScreenTouchPosition;
        currentScreenTouchPosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void Update()
    {
        startScreenTouchPosition = currentScreenTouchPosition;
    }

    private void OnMoveTwo(InputValue value) 
    {
        secondFingerPosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnTap()
    {
        Tap.Invoke(currentScreenTouchPosition);
    }

    private void OnSwipe(InputValue value)
    {
        Vector2 change = value.Get<Vector2>();

        //print(value.Get<>);
        if (Mathf.Abs(change.x) > swipeSensitivity || Mathf.Abs(change.y) > swipeSensitivity)
        {
            Swipe.Invoke(change * swipeSpeed);
        }

    }

    private void OnPress(InputValue value)
    {
        float moveDifference = Vector2.SqrMagnitude(currentScreenTouchPosition - startScreenTouchPosition);

        if (moveDifference < (holdMovement / 1.97f))
        {
            Press.Invoke(currentScreenTouchPosition);
        }
    }

    private void OnPinch(InputValue value)
    {
        Pinch.Invoke(value.Get<Vector2>().y / 200.0f);
    }

    private void OnPinchTouch(InputValue value)
    {
        float beforeDiff = Vector2.SqrMagnitude(secondFingerPosition- startScreenTouchPosition);
        Vector3 touch1change = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        float afterDiff = Vector2.SqrMagnitude( new Vector2(touch1change.x, touch1change.y) + secondFingerPosition - currentScreenTouchPosition);

        Pinch.Invoke((beforeDiff - afterDiff) * 3);
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
        gestures.FindAction("Press").ApplyParameterOverride("duration", maxTapDuration);
        //print(gestures.FindAction("Press").interactions);

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
#if UNITY_EDITOR

            InputActionAsset actions = (InputActionAsset)AssetDatabase.LoadAssetAtPath("Packages/ie.setu.gesturemanager/GMRuntime/GestureManagerControls.inputactions", typeof(InputActionAsset));

            playerIn.actions = actions;

#endif
        }
    }
}
