using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    private float dirX;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float jumpForce = 14f;
    [SerializeField] private LayerMask jumpable;
    [SerializeField] int hungerStat = 3;
    [SerializeField] bool canJump;
    [SerializeField] TextMeshProUGUI hungerText;

    // Start is called before the first frame update
    void Start()
    {
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
            changeHunger(-1);

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (hungerStat == 0)
            {
                canJump = false;
            }
        }

        if (hungerStat == 0)
        {
            canJump = false;
        }

        UpdateAnimation();

        if (Input.GetButtonDown("Submit") && (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetButtonDown("Submit") && (SceneManager.GetActiveScene().buildIndex == 5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        }

    }

    // changes hunger stat
    public void changeHunger(int amt)
    {
        if (!canJump)
        {
            canJump = true;
        }

        this.hungerStat += amt;

        hungerText.text = "Hunger: " + this.hungerStat.ToString();
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

