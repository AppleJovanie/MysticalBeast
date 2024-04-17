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

    //FootStep Sound Effect
    public AudioSource audioSource;
    public AudioClip footStep;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveLeft = false;
        moveRight = false;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
        FlipSprite(true);
        PlayFootstepSound();
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
        StopFootstepSound();
    }
    public void PointerDownRight()
    {
        moveRight = true;
        FlipSprite(false);
        PlayFootstepSound();
    }
    public void PointerUpRight()
    {
        moveRight = false;
        StopFootstepSound();
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
            anim.SetBool("running", true);
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
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
    private void FlipSprite(bool flipLeft)
    {
        spriteRenderer.flipX = flipLeft;
    }

    private void PlayFootstepSound()
    {
        if (footStep != null && audioSource != null)
        {
            audioSource.PlayOneShot(footStep);
        }
    }

    private void StopFootstepSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
