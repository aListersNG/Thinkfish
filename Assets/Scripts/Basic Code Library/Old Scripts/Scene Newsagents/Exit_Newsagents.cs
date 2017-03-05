using UnityEngine;
using System.Collections;

public class Exit_Newsagents : MonoBehaviour {

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel("Alpha_City_Centre_right");// modified by David Law

        }

    }
}
