using UnityEngine;
using System.Collections;

public class Load_Bakery_inside : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel("Alpha_Bakery_inside"); //modified by David Law

        }

    }
}
