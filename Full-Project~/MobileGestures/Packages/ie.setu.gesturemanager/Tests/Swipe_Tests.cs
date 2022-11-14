using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class Swipe_Tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Swipe_TestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Swipe_TestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator SwipeDetectionTest()
    {
        //Unable to test this automatically : will write manual test in README.

        yield return null;
    }

}
