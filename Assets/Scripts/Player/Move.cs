using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;
    public Animator anim;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveLeft = false;
        moveRight = false;
        anim =  GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
        FlipSprite(true);
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
        FlipSprite(false);
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();   
    }
    private void MovePlayer()
    {
        if (moveLeft)
        {
            anim.SetBool("running",true);
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            anim.SetBool("running", true);
            horizontalMove = speed;
        }
        else
        {
            anim.SetBool("running", false);
            horizontalMove = 0;
        }
    }
    public void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontalMove, rb.velocity.y);
    }
    private void FlipSprite(bool flipLeft)
    {
        spriteRenderer.flipX = flipLeft;
    }
}