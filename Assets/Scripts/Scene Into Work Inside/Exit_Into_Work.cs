using UnityEngine;
using System.Collections;

public class Exit_Into_Work : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel("Alpha_Into_Work_outside");// modified by David Law

        }

    }
}
