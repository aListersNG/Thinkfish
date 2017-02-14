using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LibraryNPC : MonoBehaviour {

    //The different game types that can be used
    enum GameType { CheckInBook, PrinterUsage, CheckInComputer};

    //Used for deciding the movement
    bool walkingIn, walkingOut, idle;

    //To display appropriate texts
    public String[] bookCheckIn;
    public String[] printerUsage;
    public String[] computerCheckIn;
	public Text myText;     //<-- To be implemented for use

    //If the npc's "game" is being played
    public bool gamePlaying;

    //For the body movement
    Rigidbody2D mybody;

    //To hold the game type
    GameType questType;

    //Current placeholder to make the character stop
    //Mostly for testing that the walkout worked too
    float tempGameTimer = 0.0f;

	// Use this for initialization
	void Start () {
        //Set all the default variables
        walkingIn = true;
        mybody = GetComponent<Rigidbody2D>();
        RandomGameType();
        SetText();
        }
	
	// Update is called once per frame
	void Update () {

        //Run the appropriate section
		if(walkingIn)
        {
            WalkingIn();
        }
        else if(walkingOut)
        {
            WalkingOut();
        }
        else if(idle)
        {
            GamePlay();
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
            gamePlaying = true;
            GetComponent<ChangeText>().enabled = true;
            GetComponent<ChangeText>().m_Dialogue.text = GetComponent<ChangeText>().m_dialogueOption[0];
        }
        else
        {
            //npc moves into center
            mybody.velocity = new Vector2(-2.0f, 0.0f);
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
        }
    }

    void ResetNPC()
    {
        //Set to new starting variables
        walkingOut = false;
        walkingIn = true;
        transform.position = new Vector3(10.0f, 0.0f, transform.position.z);
        RandomGameType();
        SetText();
    }

    void GamePlay()
    {
        //If the game is no longer being played, allow the character to leave
        if(!gamePlaying)
        {
            walkingOut = true;
            idle = false;
            GetComponent<ChangeText>().m_Dialogue.text = "";
            GetComponent<ChangeText>().enabled = false;
        }
        else
        {
            //Display any appropriate text
            //Run the right game
            if(tempGameTimer >= 2.0f)
            {
                tempGameTimer = 0.0f;
                gamePlaying = false;
            }
            else
            {
                tempGameTimer += Time.deltaTime;
            }
        }
    }

    void RandomGameType()
    {
        //Choose a random game type to begin
        questType = (GameType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(GameType)).Length);
    }

    void SetText()
    {
        //Currently a placeholder using the ChangeText script
        ChangeText text = GetComponent<ChangeText>();
        
        //Dependant on what game type it is, display appropriate text
        switch(questType)
        {
            case GameType.CheckInBook:
                for (int i = 0; i <= 4; i++)
                {
                    text.m_dialogueOption[i] = bookCheckIn[i];
                }

                break;
            case GameType.CheckInComputer:
                for (int i = 0; i <= 4; i++)
                {
                    text.m_dialogueOption[i] = computerCheckIn[i];
                }

                break;
            case GameType.PrinterUsage:
                for (int i = 0; i <= 4; i++)
                {
                    text.m_dialogueOption[i] = printerUsage[i];
                }

                break; 
        }
    }
}
