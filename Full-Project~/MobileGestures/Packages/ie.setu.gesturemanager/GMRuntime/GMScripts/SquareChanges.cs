using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareChanges : MonoBehaviour
{
    private SpriteRenderer sprite;
    bool big = false;
    
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColour()
    {
        sprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("Change Colour!");
    }

    public void moveSquare(Vector2 t_movement)
    {
        t_movement *= 0.05f;
        transform.position += new Vector3(t_movement.x, t_movement.y, 0);
    }

    public void changeSize(Vector2 t_pos)
    {
        Vector2 size = new Vector2();
        big = !big;

        if (big) 
        {
            size = transform.localScale * 2;
        }

        else
        {
            size = transform.localScale / 2;
        }

        transform.localScale = size;
    }
}
