using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Random update to demonstrate git bash

public class ChangeText : MonoBehaviour
{
    public Text m_Dialogue;
	public string[] m_dialogueOption;
    bool myInteract, writing;
    int i = 0;
	int currentPos = 0;
	// Use this for initialization
	void Start ()
    {
		m_Dialogue.text = m_dialogueOption [i];
    }

    // Update is called once per frame
    void Update()
    {
		if (myInteract && !writing) 
		{
			NextText ();
		} 
		else if (writing) 
		{
			AddChar ();
		}
    }

    void NextText()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			writing = true;
			if (i < (m_dialogueOption.Length - 1))
			{
				i++;
			}
			else
			{
				i = 0;
			}
			m_Dialogue.text = "";
        }
    }

	void AddChar()
	{		

		//Do a check here, remove the above when unneeded
		//To add the next character to the m_Dialogue.text
		//While there is still more character in your string
		if (currentPos < m_dialogueOption [i].Length) {
			m_Dialogue.text += m_dialogueOption [i] [currentPos];
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
            i = 0;
            m_Dialogue.text = "";
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            myInteract = false;
        }
    }
}
