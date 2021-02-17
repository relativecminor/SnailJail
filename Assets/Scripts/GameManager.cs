using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float coinCount;
    public TextMeshProUGUI coinText;

    public GameObject dialogBox;
    public GameObject dialogText;

    private Coroutine dialogCo;

    public GameObject startButton;
    public GameObject playAgainButton;
    public GameObject playAgainButtonVictory;
    public GameObject backgroundImage;
    public GameObject losingImage;
    public GameObject winningImage;
    public bool hasKey = false;

    public GameObject canvas;
    public GameObject events;
  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
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
        if (coinCount == 5)
        {
            GameManager.Instance.Win();
        }

    }

    public void collectKey()
    {
        hasKey = true;
        Debug.Log("keyCollectedGM");
    }


    public void StartDialog(string text)
    {
        dialogBox.SetActive(true);
        Debug.Log("TextStart");
        dialogCo = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray()) 
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCo);
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        Image sprite = backgroundImage.GetComponent<Image>();
        StartCoroutine(LoadYourAsyncScene("SnailWorld", sprite));
    }

    public void PlayAgainButton()
    {
        playAgainButton.SetActive(false);
        Image sprite = losingImage.GetComponent<Image>();
        StartCoroutine(LoadYourAsyncScene("SnailWorld", sprite));
    }

    public void PlayAgainButtonVictory()
    {
        playAgainButtonVictory.SetActive(false);
        Image sprite = winningImage.GetComponent<Image>();
        StartCoroutine(LoadYourAsyncScene("SnailWorld", sprite));
    }



    public void GameOver()
    {
        StopAllCoroutines();
        playAgainButton.SetActive(true);
        losingImage.SetActive(true);
        Image sprite = losingImage.GetComponent<Image>();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), .7f, sprite));
        coinCount = 0;
        coinText.text = "Coins: 0";
        hasKey = false;

    }

    public void Win()
    {
        StopAllCoroutines();
        playAgainButtonVictory.SetActive(true);
        winningImage.SetActive(true);
        Image sprite = winningImage.GetComponent<Image>();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), .7f, sprite));
        coinCount = 0;
        coinText.text = "Coins: 0";
        hasKey = false;
    }

    IEnumerator ColorLerp(Color endValue, float duration, Image sprite)
    {
        float time = 0;
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }

    IEnumerator LoadYourAsyncScene(string scene, Image sprite)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2, sprite));
    }

 

}

