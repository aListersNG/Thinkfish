using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Movement_Script : MonoBehaviour
{
    
    //Player Movement Variables
    private float moveX;
    public float moveSpeed;
    private Rigidbody2D player;

    //For animation use these variables
    public Sprite[] animationWalk;
    public Sprite animationIdle;
    float timeToChange;
    int counter;
    bool facingLeft;

    //For using the UI
    private UIManager UI;
    bool displayingUI;
    public bool talkable;

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1280, 720, false); // by David Law
        player = gameObject.GetComponent<Rigidbody2D>();// by Andy McGonigal

        UI = GetComponent<UIManager>();
        
        //Set animation variables
        counter = 0;
        timeToChange = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!displayingUI)
        {
            ManageMovement();
        }

        TalkCheck();
    }

    void ManageMovement()
{
    //If the player is Idle -- By James
    if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
    {
        //Play the idle animation and stop the player moving
        moveX = 0;
        timeToChange = 0.2f;
        counter = 0;
        this.GetComponent<SpriteRenderer>().sprite = animationIdle;
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
                counter = 0;
                timeToChange = 0.3f;
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
                counter = 0;
                timeToChange = 0.3f;
                this.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
            }
        }

        //If time for the animation is set to change
        if (timeToChange <= 0.0f)
        {
            if (counter < 3)
            {
                //Up the counter
                counter++;
            }
            else
            {
                //Reset the counter position
                counter = 0;
            }

            //Change the sprite displayed
            //Reset animation timer
            timeToChange = 0.2f;
            this.GetComponent<SpriteRenderer>().sprite = animationWalk[counter];
        }
        else
        {
            //Reduce the time
            timeToChange -= Time.deltaTime;
        }
    }

    GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, 0);
}

    void TalkCheck()
    {
        if(talkable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!displayingUI)
                {
                    UI.ShowUI();
                    displayingUI = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                }
                else
                {
                    UI.HideUI();
                    displayingUI = false;
                }
            }
        }
    }

}
