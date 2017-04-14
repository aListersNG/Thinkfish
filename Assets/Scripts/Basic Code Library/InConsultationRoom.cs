using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InConsultationRoom : MonoBehaviour
{

    public GameObject Feedback;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Feedback.GetComponent<UISlider>().inFeedbackroom = true;
        }
    }
}
