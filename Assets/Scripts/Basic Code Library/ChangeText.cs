using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Random update to demonstrate git bash

public class ChangeText : MonoBehaviour
{
    [System.Serializable]
    public struct Speech
    {
       public string m_dialogueOption;
       public bool playerSpeech;
    }

    public Speech[] npcSpeech;
    public Text m_Dialogue;
    public Sprite npcImage;

    bool myInteract, writing, isTalking, beenTalkedTo;
    int i = -1;
	int currentPos = 0;
    Player_Movement_Script myPlayer;

    // Update is called once per frame
    void Update()
    {
        if (myPlayer != null)
        {
            if (isTalking && myPlayer.CheckTalking())
            {
                if (myInteract && !writing)
                {
                    NextText();
                }
                else if (writing)
                {
                    AddChar();
                }
            }
            else if(myPlayer.CheckTalking())
            {
                isTalking = true;
                SetNextTarget();

                if(!beenTalkedTo)
                {
                    beenTalkedTo = true;
                    GameObject.FindGameObjectWithTag("FeedbackSystem").GetComponent<Feedback>().AddTalkedTo();
                }

            }
            else if(isTalking)
            {
                i = -1;
                m_Dialogue.text = "";
                myPlayer.ChangeSpeechIcon(npcImage);
                isTalking = false;
            }
        }
    }

    void NextText()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNextTarget();
        }
    }

    void SetNextTarget()
    {
        if (i < (npcSpeech.Length - 1))
        {
            i++;
            writing = true;
            if(i>0)
            {
                if(!npcSpeech[i].playerSpeech && npcSpeech[i-1].playerSpeech)
                {
                    myPlayer.ChangeSpeechIcon(npcImage);
                }
                else if(npcSpeech[i].playerSpeech && !npcSpeech[i-1].playerSpeech)
                {
                    myPlayer.ChangeSpeechIcon(null);
                }
            }
            else
            {
                if(!npcSpeech[i].playerSpeech)
                {
                    myPlayer.ChangeSpeechIcon(npcImage);
                }
                else
                {
                    myPlayer.ChangeSpeechIcon(null);
                }
            }
        }
        else
        {
            //At this point leave the chat
            myPlayer.EndTalking();
            isTalking = false;
            i = -1;
        }
        m_Dialogue.text = "";
    }


    void AddChar()
	{		

		//Do a check here, remove the above when unneeded
		//To add the next character to the m_Dialogue.text
		//While there is still more character in your string
		if (currentPos < npcSpeech[i].m_dialogueOption.Length) {
			m_Dialogue.text += npcSpeech[i].m_dialogueOption[currentPos];
			currentPos++;
		} else {
			writing = false;
			currentPos = 0;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            myInteract = true;
            i = -1;
            m_Dialogue.text = "";
            myPlayer = col.GetComponent<Player_Movement_Script>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            myInteract = false;
            if(myPlayer == col.GetComponent<Player_Movement_Script>())
            {
                myPlayer = null;
            }
        }
    }
}
