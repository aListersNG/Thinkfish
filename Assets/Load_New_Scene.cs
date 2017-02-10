﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_New_Scene : MonoBehaviour {

    public string m_Scene;

    void OnTriggerEnter2D(Collider2D col)// Developed by Andrew McGonigal
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(m_Scene);//modified by David Law

        }
    }
}
