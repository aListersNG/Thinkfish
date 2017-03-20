using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{

    public GameObject BookSprite;
    public GameObject Highlighter;
    public int booksCollected;
    public float bookInUse;
    public bool menuUp;

    private int books = 5;

    public fixed bool bookReturned[Books];

    private float bookPos;


    // Use this for initialization
    void Start()
    {
        for (int i; i < 5; i++)
        { 
            bookReturned[Books] = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //pressing space closes the menu and puts the highlighter off screen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuUp = false;
            Highlighter.transform.position = new Vector3(0, -7.0f, 0);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //choose book
            if (menuUp == true)
            {
                //change position of the highlighter
                bookPos = bookPos + 0.5f;
                if (bookPos > (booksCollected / 2))
                {
                    bookPos = 0;
                }
                Highlighter.transform.position = new Vector3(-5 + bookPos, -2.5f, 0);
                //record which book is in use currently
                bookInUse = (bookPos * 2);
            }
            //open menu
            else
            {
                Highlighter.transform.position = new Vector3(-5, -2.5f, 0);
                menuUp = true;
            }
        }
    }
}
