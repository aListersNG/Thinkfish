using UnityEngine;
using System.Collections;

public class Load_City_Centre_left : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)// Developed by Andrew McGonigal
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Alpha_City_Centre_left");// modified by David Law
            
        }
    }
}
