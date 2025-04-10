using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector2 prevTouchPos;
    private bool isDragging = false;

    public float minY;
    public float maxY;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevTouchPos = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 currentTouchPos = Input.mousePosition;
            float deltaY = (currentTouchPos.y - prevTouchPos.y) * 0.01f; 

            Vector3 newPos = transform.position - new Vector3(0, deltaY, 0);

            newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

            transform.position = newPos;

            prevTouchPos = currentTouchPos;
        }
    }




}
