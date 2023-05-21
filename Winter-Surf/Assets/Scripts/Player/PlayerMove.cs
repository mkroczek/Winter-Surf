using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 startPosition;
    public float distancePassed = 0;
    [SerializeField] SwipeControl swipeControl;
    [SerializeField] int lane = 0;
    private float laneDistance = 1.5F;
    public int sectionDistance = 0;
    public float moveSpeed = 50;
    private float sideSpeed = 7;

    // TODO: jeśli możliwe przenieść te deklaracje do GameController
    public static GameObject PLAYERINSTANCE;
    public static GameObject PLAYERCHILDINSTANCE;

    // fields connected with jumping
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] Transform groundCheck;
    private float velocity = 0;

    void Awake()
    {
        PLAYERINSTANCE = gameObject;
        PLAYERCHILDINSTANCE = transform.GetChild(1).gameObject;
        startPosition = transform.position;
    }

    public float getMoveSpeed(){
        return moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        distancePassed = Vector3.Distance(startPosition, transform.position);

        if(sectionDistance == 5){
            Debug.Log("Increase speed!");
            moveSpeed *= 2;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        SwipeControl.Direction swipeDirection = swipeControl.GetSwipe();

        HandleJumping(swipeDirection);

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

    private void HandleJumping(SwipeControl.Direction swipeDirection)
    {
        if (IsGrounded())
        {
            velocity = 0;
            if (Input.GetKeyDown(KeyCode.W) || swipeDirection == SwipeControl.Direction.UP)
            {
                Jump();
            }
            PLAYERCHILDINSTANCE.GetComponent<Animator>().Play("Fast Run");
        }
        else
        {
            velocity += Physics.gravity.y * gravityScale * Time.deltaTime;
        }
        transform.Translate(Vector3.up * Time.deltaTime * velocity, Space.World);
    }

    private void Jump()
    {
        PLAYERCHILDINSTANCE.GetComponent<Animator>().Play("Jump");
        velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
    }

    private bool IsGrounded()
    {
        return groundCheck.position.y <= 0;
    }
}
