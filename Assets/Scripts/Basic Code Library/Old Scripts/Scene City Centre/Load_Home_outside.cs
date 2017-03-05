using UnityEngine;
using System.Collections;

public class Load_Home_outside : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)// Developed by Andrew McGonigal
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Alpha_Home_outside"); // modified by David Law

        }
    }

}
