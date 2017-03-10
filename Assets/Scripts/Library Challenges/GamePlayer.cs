using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour {
   
    //For displaying the game state
    public bool gamePlaying, gameOver, gamePaused, gameComplete;
    
    //For random distractions
    float distractionTimer;
    public VignetteControl cameraControl;
    bool setDark, clickingCounts;
    public Clicker clicks;

    //For controlling score
    ScoreManager myScore;

    //The different game types that can be used
    public enum GameType { CheckInBook, CheckInBookLate, PrinterUsage, CheckInComputer };

    //The types of actions that can be done
    enum Action { CardChecked, BookDropped, CashTaken, BookStamped };

    GameType questType;
    List<Action> currentList, bookCheckIn, bookCheckInLate, printerCheck, compCheck;

    void Start()
    {
        myScore = GetComponent<ScoreManager>();
        SetDistractionTime();
        SetLists();
    }

    void Update()
    {
        if(distractionTimer <= 0.0f)
        {
            if(!clickingCounts)
            {
                clickingCounts = true;
                clicks.myClicks = 0;
            }
            //pause the game
            gamePaused = true;

            //if setting to dark
            if(setDark)
            {
                cameraControl.vignette += Time.deltaTime;
                if(cameraControl.vignette>=5.0f)
                {
                    setDark = false;
                }
            }
            else
            {
                if(clicks.myClicks >= 15)
                {
                    cameraControl.vignette -= Time.deltaTime;
                    if(cameraControl.vignette <= 0.0f)
                    {
                        cameraControl.vignette = 0.0f;
                        SetDistractionTime();
                        gamePaused = false;
                        clicks.myClicks = 0;
                    }
                }
            }
        }
        else
        {
            distractionTimer -= Time.deltaTime;
        }
    }

    void SetDistractionTime()
    {
        setDark = true;
        distractionTimer = Random.Range(16.0f, 40.0f);
    }

    public void ItemDropped(string objectTag, string sectionTag)
    {
        if(objectTag == "Book")
        {
            if(sectionTag == "BookSlot")
            {
                //currentList.Add();
                CheckIfRight();
            }
            else
            {
                TaskFailed();
            }
        }
        else if(objectTag == "Cash")
        {
            if (sectionTag == "CashDrawer")
            {
                currentList.Add(Action.CashTaken);
            }
            else
            {
                TaskFailed();
            }
        }
        else if(objectTag == "LibraryCard")
        {
            if (sectionTag == "Computer")
            {
                currentList.Add(Action.CardChecked);
            }
            else
            {
                TaskFailed();
            }
        }
    }

    public void SetQuestType(GameType gameType)
    {
        currentList = new List<Action> { };
        questType = gameType;
    }

    void TaskComplete()
    {
        currentList = null;
        gameOver = true;
        gamePlaying = false;
        gameComplete = myScore.GainPoints();
    }

    void TaskFailed()
    {
        currentList = null;
        gameOver = true;
        gamePlaying = false;
        gameComplete = myScore.LosePoints();
    }

    void SetLists()
    {
        //Checking in a book
        bookCheckIn = new List<Action> { Action.CardChecked, Action.BookStamped, Action.BookDropped };

        //Checking in a late book
        bookCheckInLate = new List<Action> { Action.CardChecked, Action.BookStamped, Action.CashTaken, Action.BookDropped };

        //Checking in for computer usage
        compCheck = new List<Action> { Action.CardChecked };

        //Checking in for printer usage
        printerCheck = new List<Action> { Action.CardChecked, Action.CashTaken };
    }

    void CheckIfRight()
    {
        switch(questType)
        {
            case GameType.CheckInBook:
                if (currentList[currentList.Count - 1] == bookCheckIn[currentList.Count - 1])
                {
                    if (currentList.Count == bookCheckIn.Count)
                    {
                        TaskComplete();
                    }
                }
                break;

            case GameType.CheckInComputer:
                if (currentList[currentList.Count - 1] == compCheck[currentList.Count - 1])
                {
                    if(currentList.Count == compCheck.Count)
                    {
                        TaskComplete();
                    }
                }
                break;

            case GameType.PrinterUsage:
                if (currentList[currentList.Count - 1] == printerCheck[currentList.Count - 1])
                {
                    if (currentList.Count == printerCheck.Count)
                    {
                        TaskComplete();
                    }
                }
                break;

            case GameType.CheckInBookLate:
                if (currentList[currentList.Count - 1] == bookCheckInLate[currentList.Count - 1])
                {
                    if (currentList.Count == bookCheckInLate.Count)
                    {
                        TaskComplete();
                    }
                }
                break;

            default:
                break;
        }
        
    }
}
