using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    private GameObject player;
    public float speed;
    private Rigidbody2D turtleRB;
    private float prevFrameX;
    private bool facingRight;
    private SpriteRenderer rend;
    private float initialSpawnDirection;
    private bool higherThanPlayer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
        turtleRB = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        higherThanPlayer = true;
        if (player.transform.position.x > transform.position.x)
        {
            facingRight = true;
            turtleRB.velocity = Vector2.right * speed;
        }
        else
        {
            turtleRB.velocity = -Vector2.right * speed;
        }
    }
	
	// Update is called once per frame
	void Update () {
        turtleRB.velocity = Vector2.right*speed;
        //this logic needs addressing
        if (player.transform.position.y > transform.position.y)
        {
            higherThanPlayer = false;
        }
        if (player.transform.position.x > transform.position.x && !higherThanPlayer)
        {
            facingRight = true;
            turtleRB.velocity = Vector2.right * speed;
        }
        else if (player.transform.position.x < transform.position.x && !higherThanPlayer)
        {
            facingRight = false;
            turtleRB.velocity = -Vector2.right * speed;
        }
        if(!higherThanPlayer)
        Flip();
    }

    void Flip()
    {
        if (facingRight)
        {
            rend.flipX = false;
            return;
        }

        rend.flipX = true;
    }
}
