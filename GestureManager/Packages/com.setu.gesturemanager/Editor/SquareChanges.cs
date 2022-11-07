using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareChanges : MonoBehaviour
{
    private SpriteRenderer sprite;
    
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour()
    {
        sprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("Change Colour!");
    }
}
