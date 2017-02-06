using UnityEngine;
using System.Collections;

//By James McNeil
//04/02/2017

public class NPCMovement : MonoBehaviour
{
    public Player_Movement_Script player;
    bool talkable;


    //The sprites for the character
    public Sprite idle;
    public Sprite[] walkAnimation;

    //for setting the correct animation
    float animationSpeed, idleTime;
    int counter;

    //For controlling how far that character shall travel
    float startPos, maxX, minX;

    //For controlling the movement and speed
    Rigidbody myBody;
    float moveSpeed, directionPause;
    bool wasGoingLeft, isIdle;

	// Use this for initialization
	void Start ()
    {
        //Get the body
        myBody = GetComponent<Rigidbody>();

        //Set the starting position of the sprite
        startPos = transform.position.x;

        //Work out top distances allowed
        float distToStrt = 4.0f;
        minX = startPos - distToStrt;
        maxX = startPos + distToStrt;

        //Set movement speed and direction
        moveSpeed = 1.0f;

        //Set correct variables for animation changes
        animationSpeed = 0.2f;
        idleTime = 1.0f;
        counter = 0;

        talkable = player.talkable;
    }
	
	// Update is called once per frame
	void Update () {
            //While the character is not idle
            if (!isIdle)
            {
                Movement();
            }
            else
            {
                TimeTillMoving();
            }
	}
    
    void Movement()
    {
        if(!AtGoal())
        {
            if (talkable == false)
            {
                //Set the velocity
                myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, myBody.velocity.z);
                //Set the animation
                MoveAnimation();
            }
        }
        else
        {
            //Stop the npc moving
            IdleAnimation();
        }
    }

    void  MoveAnimation()
    {
        if(animationSpeed <= 0.0f)
        {
            //Move to the next sprite
            if (counter < 3)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }

            //Set the new sprite and time to change back to default
            GetComponent<SpriteRenderer>().sprite = walkAnimation[counter];
            animationSpeed = 0.2f;
        }
        else
        {
            animationSpeed -= Time.deltaTime;
        }
    }

    void IdleAnimation()
    {
        //Set the movement animation variables back to default
        counter = 0;
        animationSpeed = 0.2f;

        //Stop the character from moving and display the idle sprite
        myBody.velocity = new Vector3(0.0f, myBody.velocity.y, myBody.velocity.z);
        GetComponent<SpriteRenderer>().sprite = idle;
    }

    bool AtGoal()
    {
        //If the npc is at either of the stated goals
        //Set the npc to be idle for now
        if(wasGoingLeft && transform.position.x <= minX)
        {
            isIdle = true;
            return true;
        }
        else if (!wasGoingLeft && transform.position.x >= maxX)
        {
            isIdle = true;
            return true;
        }

        //If the conditions were not met
        return false;
    }

    void TimeTillMoving()
    {
        if(idleTime <= 0.0f)
        {
            //Set the variables back to default for moving
            idleTime = 1.0f;
            isIdle = false;

            //Change the direction of the npc
            ChangeDirection();
        }
        else
        {
            idleTime -= Time.deltaTime;
        }
    }

    void ChangeDirection()
    {
        if(wasGoingLeft)
        {
            wasGoingLeft = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            wasGoingLeft = true;
        }

        //reverse the speed
        moveSpeed *= -1.0f;
    }
}
