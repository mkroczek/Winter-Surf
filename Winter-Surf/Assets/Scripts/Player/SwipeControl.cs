using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwipeControl : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private Direction swipe = Direction.NONE; 

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            swipe = GetDominantSwipeDirection(startTouchPosition, endTouchPosition);
        }
    }

    public Direction GetSwipe()
    {
        Direction direction = swipe;
        swipe = Direction.NONE;
        return direction;
    }

    private Direction GetDominantSwipeDirection(Vector2 startPosition, Vector2 endPosition)
    {
        Vector2 delta = endPosition - startPosition;

        Direction dominantDirection = Direction.LEFT;
        float dominantValue = float.NegativeInfinity;

        foreach (Direction direction in Enum.GetValues(typeof(Direction))) 
        {
            float value = Vector2.Dot(delta, GetCorrespondingVector(direction));
            if (value > dominantValue)
            {
                dominantValue = value;
                dominantDirection = direction;
            }
        }

        return dominantDirection;
    }

    private Vector2 GetCorrespondingVector(Direction direction)
    {
        switch(direction) {
            case Direction.LEFT: return Vector2.left;
            case Direction.RIGHT: return Vector2.right;
            case Direction.UP: return Vector2.up;
            case Direction.DOWN: return Vector2.down;
            case Direction.NONE:
            default: return new Vector2(0,0);
        }
    }

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
        NONE
    }
}
