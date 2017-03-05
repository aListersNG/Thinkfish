using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_IntoWork_entrance : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)// Developed by Andrew McGonigal
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Alpha_Into_Work_inside");//modified by David Law

        }
    }
}
