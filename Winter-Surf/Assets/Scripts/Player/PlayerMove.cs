using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject levelControl;
    [SerializeField] int lane = 0;
    private float laneDistance = 1.5F;
    public float moveSpeed = 3;
    private float sideSpeed = 7;

    public float getMoveSpeed(){
        return moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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
