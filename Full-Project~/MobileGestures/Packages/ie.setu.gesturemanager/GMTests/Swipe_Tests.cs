using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class Swipe_Tests
{
    //private GMGameManager game;

    //[SetUp]
    //public void Setup()
    //{
    //    GameObject gameGameObject =
    //      MonoBehaviour.Instantiate(
    //        Resources.Load<GameObject>("Prefabs/Main Camera"));
    //    game = gameGameObject.GetComponent<GMGameManager>();
    //}

    //[TearDown]
    //public void Teardown()
    //{
    //    Object.Destroy(game.gameObject);
    //}

    //// A Test behaves as an ordinary method
    //[Test]
    //public void Swipe_TestsSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //// `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator Swipe_TestsWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}

    //[UnityTest]
    //public IEnumerator SwipeDetectionTest()
    //{
    //    //Unable to test this automatically : will write manual test in README.

    //    yield return null;
    //}

    //[UnityTest]
    //public IEnumerator SquareMoveTest()
    //{
    //    GameObject square = game.GetSquare();

    //    Vector2 originalPos = square.transform.position;

    //    Vector2 movement = new Vector2(20, 20);

    //    //square.GetComponent<SquareChanges>().moveSquare(movement + originalPos, originalPos);

    //    yield return new WaitForSeconds(0.1f);

    //    Vector2 newPos = originalPos + movement;

    //    bool squareDidMove = square.transform.position == new Vector3(newPos.x, newPos.y, 0);

    //    UnityEngine.Assertions.Assert.IsTrue(squareDidMove);
    //}

}
