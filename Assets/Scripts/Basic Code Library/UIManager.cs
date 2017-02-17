using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public UnityEngine.UI.Text myText;
    public UnityEngine.UI.Image myImage;
    public UnityEngine.UI.Image textBox;

    // Use this for initialization
    void Start () {
        HideUI();
	}
	
    //Show the previously hidden UI
	public void ShowUI()
    {
        myText.enabled = true;
        myImage.enabled = true;
        textBox.enabled = true;
    }

    //Hide the UI from being seen
    public void HideUI()
    {
        myText.enabled = false;
        myImage.enabled = false;
        textBox.enabled = false;
    }

    //Set the text to whatever prompt has been handed in
    public void SetText(UnityEngine.UI.Text text)
    {
        myText.text = text.text;
    }

    //Set the passed in Image
    public void SetImage(Sprite image)
    {
        myImage.sprite = image;
    }

    public void SetTextBox(Sprite box)
    {
        textBox.sprite = box;
    }
}
