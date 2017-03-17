using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveX;
    private float moveY;
    public float moveSpeed;
    private Rigidbody2D player;

    private int directionFacing; //1 = north, 2 = east, 3 = south, 4 = west

    bool facingLeft;
    // Use this for initialization
    void Start ()
    {
        directionFacing = 2;
	}

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //Play the idle animation and stop the player moving
            moveX = 0;
            moveY = 0;
        }
        else
        {
            //If the player chooses to move right
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1;
                //Make sure the player faces the right way
                //Reset counter as appropriate
                if (directionFacing != 2)
                {
                    directionFacing = 2;
                    this.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                }
            }
            //If the player chooses to move left
            else if (Input.GetKey(KeyCode.A))
            {
                moveX = -1;
                if (directionFacing != 4)
                {
                    directionFacing = 4;
                    this.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
                }
            }
            //if the player moves up
            else if (Input.GetKey(KeyCode.W))
            {
                moveY = 1;
                if (directionFacing != 1)
                {
                    directionFacing = 1;
                    this.transform.rotation = new Quaternion(0.0f, 0.0f, 45.0f, 0.0f);
                }
            }
            //if the player moves down
            else
            {
                moveY = -1;
                if (directionFacing != 3)
                {
                    directionFacing = 3;
                    this.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                }
            }
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}
