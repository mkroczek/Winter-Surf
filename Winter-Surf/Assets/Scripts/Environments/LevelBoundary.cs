using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    private float leftSide = -1.5f;
    private float rightSide = 1.5f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getLeftBoundary()
    {
        return leftSide;
    }

    public float getRightBoundary()
    {
        return rightSide;
    }
}
