using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour {

    int overallScore = 0, npcTalkedto = 0, trashPickedUp = 0;
    float timeTakenChallenges = 0.0f, timeDistracted = 0.0f;
    public bool dayFinished;

    void Update()
    {
        if(dayFinished)
        {

            //Do whatever needed before this point
            ResetVariables();
        }
    }

    void ResetVariables()
    {
        overallScore = 0;
        npcTalkedto = 0;
        trashPickedUp = 0;
        timeTakenChallenges = 0.0f;
        timeDistracted = 0.0f;
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
    }

    public void AddTimeDistracted(float time)
    {
        timeDistracted += time;
    }

    public void AddChallengeTime(float time)
    {
        timeTakenChallenges += time;
    }

}
