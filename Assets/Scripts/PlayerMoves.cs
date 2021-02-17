using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer spriteRend;

    private float horizontal;
    private float vertical;

    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            runSpeed = 7.5f;
        }
        else
        {
            runSpeed = 5f;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if (horizontal < 0)
        {
            spriteRend.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRend.flipX = false;
        }
    }
}
