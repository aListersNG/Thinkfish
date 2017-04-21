 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGame : MonoBehaviour
{
    public int score;
    public int howManyBooks;
    public GameObject prefab;

    public bool gameRunning;
    bool booksCreated;


    // Use this for initialization
    void Start ()
    {
        booksCreated = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gameRunning)
        {
            if(booksCreated == false)
            {
                CreateBooks();
            }

            if (howManyBooks < 5)
            {
                Instantiate(prefab, new Vector3(UnityEngine.Random.Range(24f, 32f), -39.5f, 0), Quaternion.identity);
                howManyBooks++;
            }
        }
		
	}

    void CreateBooks()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefab, new Vector3(UnityEngine.Random.Range(24f, 32f), -39.5f, 0), Quaternion.identity);
        }
        howManyBooks = 5;
        booksCreated = true;
    }

    
}