using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviour {
   
    //For displaying the game state
    public bool gamePlaying, gameOver, gamePaused, gameComplete;

    //Keep track of the times needed for feedback
    float totalTimeDistracted = 0.0f;
    float totalTimePlaying = 0.0f;

    //For random distractions
    float distractionTimer;
    public VignetteControl cameraControl;
    bool setDark, clickingCounts;
    public Clicker clicks;

    //For game dates
    public Text textCurrentDate, textDueDate;
    public int[] currentDate;
    public int[] dueDate;

    //For checking when distractions should be done
    public BookOpen myBook;

    //For controlling score
    ScoreManager myScore;

    //The different game types that can be used
    public enum GameType { CheckInBook, CheckInBookLate, PrinterUsage, CheckInComputer };

    //The types of actions that can be done
    enum Action { CardChecked, BookDropped, CashTaken, BookStampedLate, BookStampedEarly };

    GameType questType;
    List<Action> currentList, bookCheckIn, bookCheckInLate, printerCheck, compCheck;

    void Start()
    {
        myScore = GetComponent<ScoreManager>();
        SetDistractionTime();
        SetLists();
        textCurrentDate.text = currentDate[0] + "/" + currentDate[1] + "/" + currentDate[2];
        textCurrentDate.enabled = false;
        textDueDate.enabled = false;
    }

    void Update()
    { 
        totalTimePlaying += Time.deltaTime;

        if(distractionTimer <= 0.0f)
        {
            totalTimeDistracted += Time.deltaTime;

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
        else if(!gameComplete && !myBook.active)
        {
            distractionTimer -= Time.deltaTime;
        }
        else if(gameComplete)
        {
            Feedback feedback = GameObject.FindGameObjectWithTag("FeedbackSystem").GetComponent<Feedback>();
            feedback.AddChallengeTime(totalTimePlaying);
            feedback.AddTimeDistracted(totalTimeDistracted);
            feedback.SetOverallScore(myScore.score);
        }
    }

    void SetDistractionTime()
    {
        setDark = true;
        distractionTimer = Random.Range(16.0f, 40.0f);
    }

    public void BookCheck(bool late)
    {
        if(late)
        {
            currentList.Add(Action.BookStampedLate);
        }
        else
        {
            currentList.Add(Action.BookStampedEarly);
        }

        CheckIfRight();
    }

    public bool StampedLate()
    {
        if (currentList.Count > 1)
        {
            if (currentList[currentList.Count - 1] == Action.BookStampedLate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public void ItemDropped(string objectTag, string sectionTag)
    {
        if(objectTag == "Book")
        {
            if(sectionTag == "BookSlot")
            {
                currentList.Add(Action.BookDropped);
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
                CheckIfRight();
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
                CheckIfRight();
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

        int day = 0, month = 0;

        if (questType == GameType.CheckInBook)
        {
            if (currentDate[0] >= 21)
            {
                month = currentDate[1] + 1;
                day = Random.Range(1, 28);
            }
            else
            {
                month = currentDate[1];
                day = Random.Range(21, 29);
            }
        }
        else if(questType == GameType.CheckInBookLate)
        {
            if (currentDate[0] >= 21)
            {
                month = currentDate[1];
                day = Random.Range(1, 20);
            }
            else
            {
                month = currentDate[1] - 1;
                day = Random.Range(21, 29);
            }
        }

        dueDate = new int[3] { day, month, currentDate[2] };

        textDueDate.text = dueDate[0] + "/" + dueDate[1] + "/" + dueDate[2];
    }

    public void ShowBookDates()
    {
        textCurrentDate.enabled = true;
        textDueDate.enabled = true;
    }

    public void HideBookDates()
    {
        textCurrentDate.enabled = false;
        textDueDate.enabled = false;
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
        bookCheckIn = new List<Action> { Action.CardChecked, Action.BookStampedEarly, Action.BookDropped };

        //Checking in a late book
        bookCheckInLate = new List<Action> { Action.CardChecked, Action.BookStampedLate, Action.CashTaken, Action.BookDropped };

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
                else
                {
                    TaskFailed();
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
                else
                {
                    TaskFailed();
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
                else
                {
                    TaskFailed();
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
                else
                {
                    TaskFailed();
                }
                break;

            default:
                break;
        }
        
    }
}
