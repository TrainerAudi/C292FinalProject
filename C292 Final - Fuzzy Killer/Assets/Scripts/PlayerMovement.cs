using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    private float dirX;

    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float jumpForce = 14f;
    [SerializeField] private LayerMask jumpable;
    [SerializeField] int hungerStat = 3;
    [SerializeField] bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();

        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded() && canJump)
        {
            hungerStat--;
            Debug.Log("Hunger: " + getHunger());

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (hungerStat == 0)
            {
                canJump = false;
            }
        }

        UpdateAnimation();
    }

    // changes hunger stat
    public void changeHunger(int hungerStat)
    {
        if (!canJump)
        {
            canJump = true;
        }

        this.hungerStat += hungerStat;
    }

    // returns the hunger stat
    public int getHunger()
    {
        return hungerStat;
    }

    // This allows running animation to be played
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpable);
    }
}

