using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LibraryNPC : MonoBehaviour {
    //For holding the Game Manager
    public GameObject gameManager;

    //The different game types that can be used
    //public enum GameType { CheckInBook, PrinterUsage, CheckInComputer };

    //For holding all needed giveable items
    public GameObject myBook, myCash, libraryCard;

    //Used for deciding the movement
    bool walkingIn, walkingOut, idle;

    //To display appropriate texts
    public String[] bookCheckIn;
    public String[] printerUsage;
    public String[] computerCheckIn;

	public Text myText;
    String[] textToDisplay;
    int textCounter = 0;
    float talkingTimer = 0.0f;
    bool finishedTalking;

    //For the body movement and animation
    Rigidbody2D mybody;
    public Sprite idleSprite;
    public Sprite[] walkAnimation;
    int animationCounter = 0;
    float animationSpeed = 0.0f;

    //To hold the game type
    GamePlayer.GameType questType;

    //To hold start pos of each item
    Vector2 libCardStartPos, bookStartPos, cashStartPos;

	// Use this for initialization
	void Start () {
        //Set all the default variables
        walkingIn = true;
        mybody = GetComponent<Rigidbody2D>();
        RandomGameType();
        SetText();

        libCardStartPos = libraryCard.transform.position;
        bookStartPos = myBook.transform.position;
        cashStartPos = myCash.transform.position;

        //Set giveable objects to false
        myBook.SetActive(false);
        myCash.SetActive(false);
        libraryCard.SetActive(false);
        }
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.GetComponent<GamePlayer>().gamePaused)
        {
            //Run the appropriate section
            if (walkingIn)
            {
                WalkingIn();
            }
            else if (walkingOut)
            {
                WalkingOut();
            }
            else if (idle)
            {
                GamePlay();
            }
        }
        else
        {
            mybody.velocity = new Vector2(0.0f, 0.0f);
        }
	}

    void WalkingIn()
    {
        //If the character is in position already
        if(transform.position.x <= 0.0f)
        {
            //stop the character from moving
            walkingIn = false;
            idle = true;
            mybody.velocity = new Vector2(0.0f, 0.0f);
            myText.text = textToDisplay[0];
        }
        else
        {
            //npc moves into center
            mybody.velocity = new Vector2(-2.0f, 0.0f);
            WalkAnimation();
        }
    }

    void WalkingOut()
    {
        //If the npc is off the screen
        //Reset all it's variables
        if(transform.position.x <= -12.0f)
        {
            ResetNPC();
        }
        else
        {
            //Move it off the screen
            mybody.velocity = new Vector2(-2.0f, 0.0f);
            WalkAnimation();
        }
    }

    void ResetNPC()
    {
        if (!gameManager.GetComponent<GamePlayer>().gameComplete)
        {
            //Set to new starting variables
            walkingOut = false;
            walkingIn = true;
            finishedTalking = false;
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
            RandomGameType();
            SetText();
            gameManager.GetComponent<GamePlayer>().gameOver = false;
        }
    }

    void GamePlay()
    {
        //If the game is no longer being played, allow the character to leave
        if (gameManager.GetComponent<GamePlayer>().gameOver)
        {
            walkingOut = true;
            idle = false;
            myText.text = "";
            RemoveItems();
        }
        else if(!finishedTalking)
        {
           PlayThroughText();
        }
    }

    void RandomGameType()
    {
        //Choose a random game type to begin
        questType = (GamePlayer.GameType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(GamePlayer.GameType)).Length);

        gameManager.GetComponent<GamePlayer>().SetQuestType(questType);
    }

    void SetText()
    {        
        //Dependant on what game type it is, display appropriate text
        switch(questType)
        {
            case GamePlayer.GameType.CheckInBook:
                textToDisplay = bookCheckIn;
                break;

            case GamePlayer.GameType.CheckInBookLate:
                textToDisplay = bookCheckIn;
                break;

            case GamePlayer.GameType.CheckInComputer:
                textToDisplay = computerCheckIn;
                break;
            case GamePlayer.GameType.PrinterUsage:
                textToDisplay = printerUsage;
                break;

            default:
                break;
        }
    }

    void PlayThroughText()
    {
        //If the timer is over 2 seconds
        if(talkingTimer > 2.0f)
        {
            //Reset timer
            talkingTimer = 0.0f;
            if(textCounter < textToDisplay.Length - 1)
            {
                //Dispaly next text
                textCounter++;
                myText.text = textToDisplay[textCounter];
            }
            else
            {
                //Reset everything and set the game to begin
                finishedTalking = true;
                textCounter = 0;
                myText.text = "";
                gameManager.GetComponent<GamePlayer>().gamePlaying = true;
                GiveItems();
            }
        }
        else
        {
            //Increase the timer
            talkingTimer += Time.deltaTime;
        }
    }

    void GiveItems()
    {
        //All require library card
        GiveLibraryCard();

        //Dependant on what game type it is, give the appropriate items
        switch (questType)
        {
            case GamePlayer.GameType.CheckInBook:
                GiveBook();
                break;

            case GamePlayer.GameType.CheckInBookLate:
                GiveBook();
                GiveCash();
                break;

            case GamePlayer.GameType.PrinterUsage:
                GiveCash();
                break;

            default:
                break;
        }
    }

    void RemoveItems()
    {
        //All required library card
        ResetLibraryCard();

        //Dependant on what game type it is,it will have given the appropriate items
        switch (questType)
        {
            case GamePlayer.GameType.CheckInBook:
                ResetBook();
                break;

            case GamePlayer.GameType.CheckInBookLate:
                ResetBook();
                ResetCash();
                break;

            case GamePlayer.GameType.PrinterUsage:
                ResetCash();
                break;

            default:
                break;
        }
    }

    void GiveLibraryCard()
    {
        libraryCard.SetActive(true);
    }

    void GiveBook()
    {
        myBook.SetActive(true);
    }

    void GiveCash()
    {
        myCash.SetActive(true);
    }

    void ResetLibraryCard()
    {
        libraryCard.transform.position = libCardStartPos;
        libraryCard.SetActive(false);
    }

    void ResetBook()
    {
        myBook.transform.position = bookStartPos;
        myBook.SetActive(false);
    } 

    void ResetCash()
    {
        myCash.transform.position = cashStartPos;
        myCash.SetActive(false);
    }

    void WalkAnimation()
    {
        if (animationSpeed <= 0.0f)
        {
            //Move to the next sprite
            if (animationCounter < 3)
            {
                animationCounter++;
            }
            else
            {
                animationCounter = 0;
            }

            //Set the new sprite and time to change back to default
            GetComponent<SpriteRenderer>().sprite = walkAnimation[animationCounter];
            animationSpeed = 0.2f;
        }
        else
        {
            animationSpeed -= Time.deltaTime;
        }
    }

    void IdleAnimation()
    {
        animationCounter = 0;
        GetComponent<SpriteRenderer>().sprite = idleSprite;
    }
}
