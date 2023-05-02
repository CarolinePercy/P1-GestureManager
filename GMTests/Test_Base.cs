using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class Test_Base
{
    protected GMGameManager game;
    protected InputTestFixture input = new InputTestFixture();


    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
          MonoBehaviour.Instantiate(
            Resources.Load<GameObject>("Prefabs/Parent"));
        game = gameGameObject.GetComponent<GMGameManager>();

        input.Setup();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);

        input.TearDown();
    }
}
