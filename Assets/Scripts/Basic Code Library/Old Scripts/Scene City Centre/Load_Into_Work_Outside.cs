using UnityEngine;
using System.Collections;

public class Load_Into_Work_Outside : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)// Developed by Andrew McGonigal
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Alpha_Into_Work_outside");// modified by David Law

        }
    }

}
