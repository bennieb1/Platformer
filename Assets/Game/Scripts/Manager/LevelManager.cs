using System;
using System.Collections;
using Game.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singelton<LevelManager>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float waitToRespwan;
    public int GemsCollected;
    public string levelToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {

        StartCoroutine(RespawnCo());

    }

    private IEnumerator RespawnCo()
    {
        
        PlayerController.Instance.gameObject.SetActive(false);
        AudioManager.Instance.PlaySfx(8);
        
        yield return new WaitForSeconds(waitToRespwan - (1 / UIController.Instance.fadeSpeed));
        UIController.Instance.FadeToBlack();
        
        yield return new WaitForSeconds(1 / UIController.Instance.fadeSpeed + .2f);
        
        UIController.Instance.FadeFromBlack();
        
        PlayerController.Instance.gameObject.SetActive(true);
        PlayerController.Instance.transform.position = CheckpointController.Instance.spawnPoint;
        playerHealthController.Instance.currentHealth = playerHealthController.Instance.maxHealth;
        UIController.Instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
       StartCoroutine(EndLevelCo());
    }
    
    private IEnumerator EndLevelCo()
    {
        AudioManager.Instance.PlaySfx(7);
        PlayerController.Instance.stopInput = true;
        CameraController.Instance.stopFollow = true;
        UIController.Instance.levelCompleteScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.Instance.FadeToBlack();
        yield return new WaitForSeconds(1 / UIController.Instance.fadeSpeed + .25f);
       SceneManager.LoadScene(levelToLoad);
       
    }
}

