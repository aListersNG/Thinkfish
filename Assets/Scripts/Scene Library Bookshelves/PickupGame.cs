using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGame : MonoBehaviour
{
    public int score;
    public int howManyBooks;
    public GameObject prefab;


    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefab, new Vector3(UnityEngine.Random.Range(0f, 5f), -2.5f, 0), Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void increaseScore()
    {
        score++;
    }

    
}