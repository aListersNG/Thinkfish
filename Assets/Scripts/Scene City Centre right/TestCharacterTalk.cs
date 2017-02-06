using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCharacterTalk : MonoBehaviour
{
    public Player_Movement_Script player;
    bool talkable;
    // Use this for initialization
    void Start()
    {
        //hide object
        gameObject.GetComponent<Renderer>().enabled = false;
        talkable = player.talkable;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        //show object when it collides with player
        if (col.gameObject.tag == "Player")
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                player.talkable = true;
            }

        //ideally start dialogue here but that's still being developed
     }
        //when player is no longer colliding then hide object again.
        void OnTriggerExit2D(Collider2D col)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                player.talkable = false;
            }
    }
