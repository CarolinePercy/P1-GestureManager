using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GestureManager : MonoBehaviour
{
    public UnityEvent Tap;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {

            if (touch.fingerId == 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Tap.Invoke();
                }
            }
        }
    }
}
