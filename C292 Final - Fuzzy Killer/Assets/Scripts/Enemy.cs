using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float distance;

    [SerializeField] GameObject player;
    [SerializeField] float speed = 10f;
    [SerializeField] Rigidbody2D rb;

    // aggro variable - not done
    // public bool isClose = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (gameObject.tag == "Slime")
        {
            speed = 2f; 
        }
        if (gameObject.tag == "Bat")
        {
            speed = 4f;
        }

        rb.velocity = new Vector2(0 - speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Bat")
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PointA")
        {
            sprite.flipX = true;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (collision.gameObject.tag == "PointB")
        {
            sprite.flipX = false;
            rb.velocity = new Vector2(0 - speed, rb.velocity.y);
        }
    }
}
