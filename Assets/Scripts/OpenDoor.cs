using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private AudioSource sound;

    public PolygonCollider2D collide;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
            if (GameManager.Instance.hasKey)
            {
                sound.Play();
                collide.enabled = false;
                Destroy(gameObject, sound.clip.length);
            }
        }
    }
}
