using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LibraryNPC : MonoBehaviour {

    enum GameType { CheckInBook, PrinterUsage, CheckInComputer};

    //Used for deciding the movement
    bool walkingIn, walkingOut, idle;

    public String[] bookCheckIn;
    public String[] printerUsage;
    public String[] computerCheckIn;

    public bool gamePlaying;

    Rigidbody2D mybody;

    GameType questType;

    float tempGameTimer = 0.0f;

	// Use this for initialization
	void Start () {
        walkingIn = true;
        mybody = GetComponent<Rigidbody2D>();
        RandomGameType();
        SetText();
        }
	
	// Update is called once per frame
	void Update () {

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
        if(transform.position.x <= -12.0f)
        {
            ResetNPC();
        }
        else
        {
            mybody.velocity = new Vector2(-2.0f, 0.0f);
        }
    }

    void ResetNPC()
    {
        walkingOut = false;
        walkingIn = true;
        transform.position = new Vector3(10.0f, 0.0f, transform.position.z);
        RandomGameType();
        SetText();
    }

    void GamePlay()
    {
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
        questType = (GameType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(GameType)).Length);
    }

    void SetText()
    {
        ChangeText text = GetComponent<ChangeText>();
        
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
