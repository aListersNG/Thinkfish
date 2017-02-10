using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    public Text m_Dialogue;
	public string[] m_dialogueOption;
    int i = 0;
	// Use this for initialization
	void Start ()
    {
		m_Dialogue.text = m_dialogueOption [i];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
			m_Dialogue.text = m_dialogueOption [i];
            //m_Dialogue = gameObject.GetComponent<Text>();
            //if (i == 0)
            //{
            //    m_Dialogue.text = "<insert other dialogue>";
            //}
			//
            //if (i == 1)
            //{
            //    m_Dialogue.text = "<insert other other dialogue>";
            //}
			//
            //if (i == 2)
            //{
            //    m_Dialogue.text = "<insert reating dialogue>";
            //}

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
			if (i < 2) {
				i++;
			} else {
				i = 0;
			}
        }
    }
}
