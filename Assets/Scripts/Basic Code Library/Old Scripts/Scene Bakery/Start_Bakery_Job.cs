using UnityEngine;
using System.Collections;

public class Start_Bakery_Job : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {
                Application.LoadLevel("Alpha_Bakery_Job");//modified by David Law
        }

    }
}

