﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{

    public GameObject Highlighter;
    public GameObject BookSprite1;
    public GameObject BookSprite2;
    public GameObject BookSprite3;
    public GameObject BookSprite4;
    public GameObject BookSprite5;
    public GameObject Shelf0;
    public GameObject Shelf1;
    public GameObject Shelf2;
    public GameObject Shelf3;
    public GameObject Shelf4;
    public GameObject ScoreKeeper;
    public int booksCollected;
    public float bookInUse;
    public bool menuUp;
    int score;

    private float bookPos;

    private bool[] bookReturned = new bool[6];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < booksCollected; i++)
        {
            bookReturned[i] = false;
        }
        if (ScoreKeeper == null)
        {
            ScoreKeeper = GameObject.FindWithTag("FeedbackSystem");
        }
    }



    // Update is called once per frame
    void Update()
    {
        //pressing space closes the menu and puts the highlighter off screen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuUp = false;
            Highlighter.transform.position = new Vector3(0, -7.0f, 0);
        }
        //this large if statement decides which books are meant to be up. Sorry about the mess, I got stuck.
        //if the menu isn't up
        if (menuUp == false)
        {
            //by default the books shouldn't be seen
            BookSprite1.GetComponent<Renderer>().enabled = false;
            BookSprite2.GetComponent<Renderer>().enabled = false;
            BookSprite3.GetComponent<Renderer>().enabled = false;
            BookSprite4.GetComponent<Renderer>().enabled = false;
            BookSprite5.GetComponent<Renderer>().enabled = false;
            //if the book has been returned then don't show the book.
            if (bookReturned[1] == true )
            {
                BookSprite1.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite1.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[2] == true)
            {
                BookSprite2.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite2.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[3] == true)
            {
                BookSprite3.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite3.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[4] == true)
            {
                BookSprite4.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite4.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[5] == true)
            {
                BookSprite5.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite5.GetComponent<Renderer>().enabled = true;
            }
        }
        else
        {
            BookSprite1.GetComponent<Renderer>().enabled = true;
            BookSprite2.GetComponent<Renderer>().enabled = true;
            BookSprite3.GetComponent<Renderer>().enabled = true;
            BookSprite4.GetComponent<Renderer>().enabled = true;
            BookSprite5.GetComponent<Renderer>().enabled = true;

            if (bookReturned[1] == true)
            {
                BookSprite1.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite1.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[2] == true)
            {
                BookSprite2.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite2.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[3] == true)
            {
                BookSprite3.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite3.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[4] == true)
            {
                BookSprite4.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite4.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[5] == true)
            {
                BookSprite5.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite5.GetComponent<Renderer>().enabled = true;
            }
        }
        
        if(Shelf0.GetComponent<ReturnReturnedBook>().returned == true)
        {
            bookReturned[1] = true;
            score++;
        }
        if (Shelf1.GetComponent<ReturnReturnedBook>().returned == true)
        {
            bookReturned[2] = true;
            score++;
        }
        if (Shelf2.GetComponent<ReturnReturnedBook>().returned == true)
        {
            bookReturned[3] = true;
            score++;
        }
        if (Shelf3.GetComponent<ReturnReturnedBook>().returned == true)
        {
            bookReturned[4] = true;
            score++;
        }
        if (Shelf4.GetComponent<ReturnReturnedBook>().returned == true)
        {
            bookReturned[5] = true;
            score++;
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
                Highlighter.transform.position = new Vector3(-5 + bookPos, -2.5f, 0);
                menuUp = true;
            }
        }
    }
}
