using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyStomp : MonoBehaviour
{

    public GameObject deathEffect;
    public GameObject collectible;

    [Range(0,100)]public float chanceToDrop;
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
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            
            PlayerController.Instance.Bounce();


            float dropSelect = Random.Range(0, 100f);

            if (dropSelect<=chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
            AudioManager.Instance.PlaySfx(3);
        }
    }
}
