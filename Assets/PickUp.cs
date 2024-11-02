using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isGem,isHealth;
    public GameObject pickUpEffect;

    private bool isCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isCollected)
        {

            if (isGem)
            {

                LevelManager.Instance.GemsCollected++;
                

                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickUpEffect, transform.position, transform.rotation);
                
                UIController.Instance.UpdateGem();
                AudioManager.Instance.PlaySfx(6);
            }

            if (isHealth)
            {
                if (playerHealthController.Instance.currentHealth != playerHealthController.Instance.maxHealth)
                {
                    playerHealthController.Instance.currentHealth++;
                   
                    if (playerHealthController.Instance.currentHealth > playerHealthController.Instance.maxHealth)
                    {
                        playerHealthController.Instance.currentHealth = playerHealthController.Instance.maxHealth;
                    }
                    Destroy(gameObject);
                    Instantiate(pickUpEffect, transform.position, transform.rotation);
                    AudioManager.Instance.PlaySfx(7);
                    UIController.Instance.UpdateHealthDisplay();
                }
               

            }
            
        }
        
    }
}
