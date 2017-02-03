using UnityEngine;
using System.Collections;

public class Player_Movement_Script : MonoBehaviour
{
    //Player Movement Variables

    private float moveX;
    public float moveSpeed;
    public float EntryPosition;
    public Animator PlayerAnimator;
    public Transform playerTransform;
    private Rigidbody2D player;
   

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1280, 720, false); // by David Law
        player = gameObject.GetComponent<Rigidbody2D>();// by Andy McGonigal
    }

    // Update is called once per frame
    void FixedUpdate()//by Andy McGonigal
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        moveX = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, 0);

    }
}
