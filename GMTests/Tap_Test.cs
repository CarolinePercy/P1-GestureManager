using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class Tap_Test : Test_Base
{
    [Test]
    public void TapDetectionTest()
    {
        Touchscreen ts = InputSystem.AddDevice<Touchscreen>();
        input.BeginTouch(0, new Vector2(10, 10), false, ts);

    }
}
