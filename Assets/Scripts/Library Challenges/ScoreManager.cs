using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int score, failures;
    public bool gameOver;

	// Use this for initialization
	void Start () {
        score = 0;
        failures = 0;
	}
	
    //To be called when the player completes a task
	public bool GainPoints()
    {
        score += 5;
        CheckScore();
        return gameOver;
    }

    //To be called when the player fails a task
    public bool LosePoints()
    {
        score -= 2;
        failures++;
        CheckFails();
        return gameOver;
    }

    //Checks whether the max fails has been hit
    void CheckFails()
    {
        if(failures==3)
        {
            gameOver = true;
        }
    }

    //Checks if the score has hit the winning number
    void CheckScore()
    {
        if(score >= 25)
        {
            gameOver = true;
        }
    }
}
