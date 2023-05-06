using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareChanges : MonoBehaviour
{
    private SpriteRenderer sprite;
    bool big = false;
    Vector2 bounds;
    
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void ChangeColour()
    {
        sprite.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("Change Colour!");
    }

    public void moveSquare(Vector2 t_movement)
    {
        t_movement *= 0.05f;

        Vector3 newPos = new Vector3(t_movement.x, t_movement.y, 0) + transform.position;

        transform.position = new Vector3(Mathf.Clamp(newPos.x, bounds.x * -1, bounds.x), Mathf.Clamp(newPos.y, bounds.y * -1, bounds.y), newPos.z);
        //transform.position = newPos;
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

    public void zoomIn(float t_change)
    {
        Camera.main.orthographicSize += t_change;

        if (Camera.main.orthographicSize < 0)
        {
            Camera.main.orthographicSize = 0.01f;
        }
    }
}
