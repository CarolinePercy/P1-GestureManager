using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SwipeEvent : UnityEvent<Vector2, Vector2> { }

[System.Serializable]
public class TapEvent : UnityEvent<Vector2> { }


public class GestureManager : MonoBehaviour
{
    [Range(1, 10)]
    public int swipeSensitivity = 1;

    [Range(1, 10)]
    public int pressLength = 1;

    public TapEvent Tap;
    public SwipeEvent Swipe;

    private Vector2 startScreenTouchPosition;
    private Vector2 currentScreenTouchPosition;

    private float tapTime;
    private bool tapping = false;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0)
            {
                TapCheck();
            }
        }
    }

    void TapCheck()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            tapping = true;
            startScreenTouchPosition = GetTouchScreenPosition();
            currentScreenTouchPosition = startScreenTouchPosition;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (tapTime < pressLength * 0.1)
            {
                Tap.Invoke(currentScreenTouchPosition);
            }

            tapping = false;
            tapTime = 0;
        }

        if (tapping)
        {
            tapTime += Time.deltaTime;

            if (tapping)
            {
                currentScreenTouchPosition = GetTouchScreenPosition();

                float dis = Vector2.Distance(currentScreenTouchPosition, startScreenTouchPosition);

                if (dis > swipeSensitivity * 0.05)
                {
                    Swipe.Invoke(currentScreenTouchPosition, startScreenTouchPosition);
                }
            }
        }
    }

    Vector2 GetTouchScreenPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    }
}
