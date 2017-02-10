using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Into_Work_groundfloor2 : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel("Alpha_Into_Work_outside");// modified by David Law

        }

    }
}
