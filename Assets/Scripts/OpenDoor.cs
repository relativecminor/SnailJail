using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public PolygonCollider2D collide;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Enter");

        if (collision.gameObject.CompareTag("Player"))
        {
            collide.enabled = false;
            Destroy(gameObject);
        }
    }
}
