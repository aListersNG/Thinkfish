using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{

    public GameObject BookSprite;
    public GameObject Highlighter;
    public int booksCollected;
    public int bookInUse;

    private float bookPos;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < booksCollected; i++)
            {
                Instantiate(BookSprite, new Vector3(-5 + (i * 0.5f), -2.5f, 0), Quaternion.identity);
            }
        Highlighter.transform.position = new Vector3(-5, -2.5f, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            bookPos = bookPos + 0.5f;
            if (bookPos > (booksCollected / 2))
            {
                bookPos = 0;
            }
            Highlighter.transform.position = new Vector3(-5 + bookPos, -2.5f, 0);
        }
        
    }
}
