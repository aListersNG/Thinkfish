using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour {
    
    int overallScore = 0, npcTalkedto = 0, trashPickedUp = 0;
    float timeTakenChallenges = 0.0f, timeDistracted = 0.0f;
    bool wonLibraryDeskChallenge;
    int tasksComplete = 0;
    public bool dayFinished;
    bool textDisplayed;
    Text myText;
    List<string> feedbackText;
    
    void Start()
    {
        feedbackText = new List<string>();
    }

    void Update()
    {
        if(dayFinished && !textDisplayed)
        {
            myText = GameObject.FindGameObjectWithTag("FeedbackText").GetComponent<Text>();

            if (myText)
            {
                //See what the feedback should say
                DecideFeedback();

                //Dispaly the appropriate feedback
                ShowText();

                //Reset all the variables for the next day
                ResetVariables();
            }

        }
        else if(textDisplayed)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myText.text = "";
                textDisplayed = false;
            }
        }
    }

    void ResetVariables()
    {
        overallScore = 0;
        npcTalkedto = 0;
        trashPickedUp = 0;
        tasksComplete = 0;
        timeTakenChallenges = 0.0f;
        timeDistracted = 0.0f;
        dayFinished = false;
        wonLibraryDeskChallenge = false;
        feedbackText.Clear();
    }

    public void AddTalkedTo()
    {
        npcTalkedto++;
    }

    public void OnTrashPickUp()
    {
        trashPickedUp++;
    }

    public void SetOverallScore(int score)
    {
        if(score>25)
        {
            score = 25;
        }
        else if (score<0)
        {
            score = 0;
        }

        overallScore += score;
        tasksComplete++;
    }

    public void AddTimeDistracted(float time)
    {
        timeDistracted += time;
    }

    public void AddChallengeTime(float time)
    {
        timeTakenChallenges += time;
    }

    public int GetTasksCompleted()
    {
        return tasksComplete;
    }

    void DecideFeedback()
    {
        if(npcTalkedto >= 5)
        {
            feedbackText.Add("Orla was friendly with customers and staff; she was a great communicator");
        }

        if (overallScore == 50)
        {
            feedbackText.Add("Orla did excellently at the tasks I assigned her. She’s clearly a Hard Worker.");

            if (timeTakenChallenges <= 150)
            {
                feedbackText.Add("Orla has Excellent time management skill, she got her work done in record time!");
            }
        }
        else if (overallScore >= 45)
        {
            feedbackText.Add("Orla was a great help this week, really brilliant worker. ");
        }
        else if (overallScore >= 40)
        {
            feedbackText.Add("Orla did quite well at her placement this week, she helped out a lot.");
        }
        else if (overallScore >= 35)
        {
            feedbackText.Add("Orla was a good help this week. ");
        }
        else if (overallScore >= 30)
        {
            feedbackText.Add("Orla worked decently well this week");
        }
        else if (overallScore >= 25)
        {
            feedbackText.Add("Orla worked decently well this week. She could do better, though.");
        }
        else if (overallScore >= 0)
        {
            feedbackText.Add("Orla could've done a lot better this week. It was a little disappointing.");
        }

        if(trashPickedUp >= 10)
        {
            feedbackText.Add("Kept the *workplace*neat and Tidy");
        }

        if(timeTakenChallenges <= 70)
        {
            feedbackText.Add("Orla kept track of her tasks surprisingly well. She was much better Organised than I had expected");
        }

        if(timeDistracted <= 10)
        {
            feedbackText.Add("Orla is a Highly Motivated worker, she kept focused and worked especially hard to achieve her tasks ");
        }

        if(wonLibraryDeskChallenge)
        {
            feedbackText.Add("Orla did a great job at the front desk, she was Helpful and Approachable for customers. ");
        }
    }

    void ShowText()
    {
        int counter = 0;
        int charCount = 0;
        bool textWriting = true;        
        
        while(textWriting)
        {
            if (charCount < feedbackText[counter].Length)
            {
                myText.text += feedbackText[counter][charCount];
                charCount++;
            }
            else
            {
                charCount = 0;
                if (counter < feedbackText.Count -1)
                {
                    counter++;
                    myText.text += "\n\n";
                }
                else
                {
                    textWriting = false;
                }
            }
        }

        textDisplayed = true;
    }

}
