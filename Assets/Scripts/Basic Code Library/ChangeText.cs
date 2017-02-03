using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    Text m_Dialogue;
    int i = 0;
	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            m_Dialogue = gameObject.GetComponent<Text>();
            if (i == 0)
            {
                m_Dialogue.text = "<insert other dialogue>";
            }

            if (i == 1)
            {
                m_Dialogue.text = "<insert other other dialogue>";
            }

            if (i == 2)
            {
                m_Dialogue.text = "<insert reating dialogue>";
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            i++;
        }
    }
}
