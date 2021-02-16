using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullitenScript : MonoBehaviour
{

    public string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.StartDialog(text);
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HideDialog();
        }
    }

}
