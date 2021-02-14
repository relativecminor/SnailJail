using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailerMovement : MonoBehaviour
{
    // Set this moveType variable to 0,1,2 to determine the jailer's movement
    // 0 is horizontal movement
    // 1 is vertical movement
    // 2 is maybe set to follow the player
    // 3 is stand still
    public int moveType;
    public float pathLength;
    private float pathTracker;
    private float speed;
    private bool directionRight;
    Rigidbody2D body;
    SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        pathTracker = 0f;
        speed = .005f;
        directionRight = true;
        body = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathTracker < 0 || pathTracker > pathLength)
        {
            directionRight = !directionRight;
            spriteRend.flipX = !directionRight;
        }
        if (moveType == 0)
        {
            Horizontal(pathLength);
        }
        else if (moveType == 1)
        {
            Vertical(pathLength);
        }
        else if (moveType == 2)
        {
            Follow();
        }
    }

    void Horizontal(float pathLenth)
    {
        if (directionRight)
        {
            body.transform.position = new Vector2( transform.position.x + speed, transform.position.y);
            pathTracker += 1;
        }
        else
        {
            body.transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            pathTracker -= 1;
        }
        
    }

    void Vertical(float pathLenth)
    {
        if (directionRight)
        {
            body.transform.position = new Vector2(transform.position.x, transform.position.y + speed);
            pathTracker += 1;
        }
        else
        {
            body.transform.position = new Vector2(transform.position.x, transform.position.y - speed);
            pathTracker -= 1;
        }
    }

    void Follow()
    {

    }

}
