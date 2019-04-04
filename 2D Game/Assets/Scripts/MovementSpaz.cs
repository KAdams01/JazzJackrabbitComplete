using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpaz : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    public float speed;
    private bool lastTimeRight;

    private Rigidbody2D rb2d;
    private bool jump;
    private Animator animator;
    private float move;
    private SoundManager sm;
    private bool grounded;
    private int layerMask = 1 << 12;

    // Use this for initialization
    void Start()
    {
        sm = SoundManager.Instance;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastTimeRight = transform.localScale.x != -1;
        layerMask = ~layerMask;
    }

    private void Update()
    {
        jump = Input.GetButtonDown("Jump2");
        move = Input.GetAxis("Horizontal2");

        if (move > 0.1 && !lastTimeRight)
        {
            FlipCharacter();
            animator.SetBool("lastTimeRight", true);
            animator.SetFloat("speed", Mathf.Abs(move));
        }
        //changes to 0.1 rather than 0 for both of these for logic issues 
        else if (move < 0.1 && lastTimeRight)
        {
            FlipCharacter();
            animator.SetBool("lastTimeRight", true);
            animator.SetFloat("speed", Mathf.Abs(move));
        }

        else
        {
            animator.SetFloat("speed", Mathf.Abs(move));
        }

        Jump();
    }

    private void FlipCharacter()
    {
        lastTimeRight = !lastTimeRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
    }


    private void Jump()
    {
        RaycastHit2D ray2d = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);
        float distance = Mathf.Abs(ray2d.point.y - transform.position.y);
        if (distance > 0.58 || !jump)
        {
            return;
        }
        else
        {
            sm.PlaySoundEffect("Jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

    }
}
