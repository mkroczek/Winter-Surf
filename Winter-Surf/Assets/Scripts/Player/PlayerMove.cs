using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] SwipeControl swipeControl;
    [SerializeField] int lane = 0;
    private float laneDistance = 1.5F;
    public float moveSpeed = 3;
    private float sideSpeed = 7;

    // TODO: jeśli możliwe przenieść te deklaracje do GameController
    public static GameObject PLAYERINSTANCE;
    public static GameObject PLAYERCHILDINSTANCE;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    void Awake()
    {
        PLAYERINSTANCE = gameObject;
        PLAYERCHILDINSTANCE = transform.GetChild(1).gameObject;
    }

    public float getMoveSpeed(){
        return moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        SwipeControl.Direction swipeDirection = swipeControl.GetSwipe();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || swipeDirection == SwipeControl.Direction.LEFT)
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || swipeDirection == SwipeControl.Direction.RIGHT)
        {
            MoveRight();
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(laneDistance * lane, transform.position.y, transform.position.z), Time.deltaTime * sideSpeed);
    }

    private void MoveLeft()
    {
        if (lane > -1)
        {
            lane --;
        }
    }

    private void MoveRight()
    {
        if (lane < 1)
        {
            lane ++;
        }
    }
}
