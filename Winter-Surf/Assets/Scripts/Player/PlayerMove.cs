using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject levelControl;
    private LevelBoundary levelBoundary;
    private float moveSpeed = 3;
    private float sideSpeed = 2;

    void Awake()
    {
        levelBoundary = levelControl.GetComponent<LevelBoundary>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveRight();
        }
    }

    private void moveLeft()
    {
        if (this.gameObject.transform.position.x > levelBoundary.getLeftBoundary())
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }
    }

    private void moveRight()
    {
        if (this.gameObject.transform.position.x < levelBoundary.getRightBoundary())
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed);
        }
    }
}
