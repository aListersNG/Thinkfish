using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

    public int myClicks;

    //Just add a click every time it happens
    void OnMouseDown()
    {
        myClicks++;
    }
}
