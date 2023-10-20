using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int MAX_X_VELOCITY = 5;
    [SerializeField] int MAX_Y_VELOCITY = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, 8);
            if (GetComponent<Rigidbody2D>().velocity.y > MAX_Y_VELOCITY)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, MAX_Y_VELOCITY);
            }
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(5, 0);
            if (GetComponent<Rigidbody2D>().velocity.x > MAX_X_VELOCITY)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(MAX_X_VELOCITY, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-5, 0);
            if (GetComponent<Rigidbody2D>().velocity.x < 0- MAX_X_VELOCITY)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0-MAX_X_VELOCITY, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        
    }
}
