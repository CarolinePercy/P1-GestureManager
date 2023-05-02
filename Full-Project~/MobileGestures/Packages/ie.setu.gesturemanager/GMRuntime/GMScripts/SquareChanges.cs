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

    public void ChangeColour()
    {
        sprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("Change Colour!");
    }

    public void moveSquare(Vector2 t_newPos)
    {
        transform.position = t_newPos;
    }
}
