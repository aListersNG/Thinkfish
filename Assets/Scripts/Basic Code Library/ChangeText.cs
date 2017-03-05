using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    public Text m_Dialogue;
	public string[] m_dialogueOption;
    bool myInteract;
    int i = 0;
	// Use this for initialization
	void Start ()
    {
		m_Dialogue.text = m_dialogueOption [i];
    }

    // Update is called once per frame
    void Update()
    {
        if(myInteract)
        {
            NextText();
        }
    }

    void NextText()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Dialogue.text = m_dialogueOption[i];

            if (i < (m_dialogueOption.Length - 1))
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            myInteract = true;
            i = 0;
            m_Dialogue.text = m_dialogueOption[i];
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
