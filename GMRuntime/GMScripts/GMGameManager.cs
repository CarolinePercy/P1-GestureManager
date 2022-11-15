using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject squareModel;

    public GameObject GetSquare()
    {
        return squareModel;
    }
}
