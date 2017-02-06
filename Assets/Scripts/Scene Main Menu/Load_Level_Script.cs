using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Load_Level_Script : MonoBehaviour
{

    void Start()
    {
        Screen.SetResolution(1280, 720, false);// By David Law
    }


    void Update()
    {

    }

	public void ChangeScene(string Alpha_Player_Movement)//by Andy McGonigal
    {
        Application.LoadLevel("Alpha_Home_outside");//Line Modified by David Law
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
