using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_E_To_Enter_New_Scene : MonoBehaviour {

    public string m_Scene;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel(m_Scene);// modified by David Law

        }

    }
}
