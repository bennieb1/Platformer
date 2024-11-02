using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singelton<UIController>
{


    public Image Heart1, Heart2, Heart3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite heartFull, heartHalf, heartEmpty;

    public TextMeshProUGUI gemTxt;
    
    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;
    
    public GameObject levelCompleteScreen;
    void Start()
    {
        shouldFadeFromBlack = true;
        
     UpdateGem();   
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
            
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
            
        }
        
    }

    public void UpdateHealthDisplay()
    {
        switch (playerHealthController.Instance.currentHealth)
        {
            case 6 :
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                break;
            case 5 :
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartHalf;
                break;
            case 4 :
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;
                break;
            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartHalf;
                Heart3.sprite = heartEmpty;
                break;
            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                break;
            case 1 :
                Heart1.sprite = heartHalf;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                break;
            case 0 :
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                break;
            
        }
    }

    public void UpdateGem()
    {

        gemTxt.text = LevelManager.Instance.GemsCollected.ToString();

    }
    
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    
    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
