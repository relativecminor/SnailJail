using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public bool haskey;

    private AudioSource sound;
    private PolygonCollider2D collide;
    private SpriteRenderer image;
    public GameObject particles;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        sound = GetComponent<AudioSource>();
        collide = GetComponent<PolygonCollider2D>();
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("key gotten");
            haskey = true;
            sound.Play();
            particles.GetComponent<ParticleSystem>().Play();
            collide.enabled = false;
            image.enabled = false;
            Destroy(gameObject, sound.clip.length);

            GameManager.Instance.collectKey();
        }
    }
}
