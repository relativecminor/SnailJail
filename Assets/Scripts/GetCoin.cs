using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{

    private AudioSource sound;
    private SpriteRenderer image;
    private CircleCollider2D collide;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        image = GetComponent<SpriteRenderer>();
        collide = GetComponent<CircleCollider2D>();
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
            sound.Play();
            particles.GetComponent<ParticleSystem>().Play();
            collide.enabled = false;
            image.enabled = false;
            Destroy(gameObject, sound.clip.length);

            GameManager.Instance.collectCoin();
        }
    }

}
