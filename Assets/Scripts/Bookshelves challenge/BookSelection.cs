using System.Collections;
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
    public int booksCollected;
    public float bookInUse;
    public bool menuUp;

    private float bookPos;

    private bool[] bookReturned = new bool[6];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < booksCollected; i++)
        {
            bookReturned[i] = false;
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
        //if the menu is up and the book isn't returned then it should show up on the menu
        if (menuUp == false)
        {
            if (bookReturned[1] == false)
            {
                BookSprite1.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite1.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[2] == false)
            {
                BookSprite2.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite2.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[3] == false)
            {
                BookSprite3.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite3.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[4] == false)
            {
                BookSprite4.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                BookSprite4.GetComponent<Renderer>().enabled = true;
            }

            if (bookReturned[5] == false)
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
        }
        if (menuUp == false)
        {

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
