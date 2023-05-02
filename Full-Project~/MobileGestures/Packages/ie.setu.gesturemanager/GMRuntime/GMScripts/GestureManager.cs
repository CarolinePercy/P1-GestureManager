using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

//[System.Serializable]
//public class SwipeEvent : UnityEvent<Vector2, Vector2> { }

[System.Serializable]
public class TapEvent : UnityEvent<Vector2> { }


public class GestureManager : MonoBehaviour
{
    [Range(1, 10)]
    public int swipeSensitivity = 1;

    public TapEvent Tap;
    //public SwipeEvent Swipe;

    private Vector2 startScreenTouchPosition;
    private Vector2 currentScreenTouchPosition;


    private void OnMove(InputValue value)
    {
        currentScreenTouchPosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnTap()
    {
        Tap.Invoke(currentScreenTouchPosition);
    }

    void Reset()
    {
        PlayerInput playerIn;

        if (GetComponent<PlayerInput>() == null)
        {
           playerIn = gameObject.AddComponent<PlayerInput>();
        }

        else
        {
            playerIn = GetComponent<PlayerInput>();
        }

        InputActionAsset actions = Resources.Load<InputActionAsset>("GestureManagerControls");

        playerIn.actions = actions;
        playerIn.camera = Camera.main;
    }
}
