using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PutBookAway : MonoBehaviour
{
    public GameObject BookIcon;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
       if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
       {
           Destroy(gameObject);
           BookIcon.GetComponent<PickupGame>().score += 1;
           BookIcon.GetComponent<PickupGame>().howManyBooks -= 1;
       }

    }
}