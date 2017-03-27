using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour {

    int overallScore = 0, npcTalkedto = 0, trashPickedUp = 0;
    float timeTakenChallenges = 0.0f, timeDistracted = 0.0f;

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
        overallScore += score;
    }
}
