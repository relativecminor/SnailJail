using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float coinCount;
    public TextMeshProUGUI coinText;
  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: 0";
        coinCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectCoin()
    {
        coinCount += 1;
        Debug.Log(coinCount);
        coinText.text = "Coins: " + coinCount;

    }

}
