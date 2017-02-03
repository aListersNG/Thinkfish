using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    Text m_Dialogue;

	// Use this for initialization
	void Start ()
    {
        m_Dialogue = gameObject.GetComponent<Text>();
        m_Dialogue.text = "<insert other dialogue";

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
