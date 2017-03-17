using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveX;
    private float moveY;
    public float moveSpeed;
    private Rigidbody2D player;

    bool facingLeft;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            //Play the idle animation and stop the player moving
            moveX = 0;
        }
        else
        {
            //If the player chooses to move right
            if (Input.GetKey(KeyCode.D))
            {
                moveX = 1;
                //Make sure the player faces the right way
                //Reset counter as appropriate
                if (facingLeft == true)
                {
                    facingLeft = false;
                    this.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                }
            }
            //If the player chooses to move left
            else if (Input.GetKey(KeyCode.A))
            {
                moveX = -1;
                if (facingLeft == false)
                {
                    facingLeft = true;
                    this.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
                }
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //Play the idle animation and stop the player moving
            moveY = 0;
        }
            if (Input.GetKey(KeyCode.W))
            {
                moveY = 1;
                //this.transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveY = -1;
                // this.transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
            }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}
