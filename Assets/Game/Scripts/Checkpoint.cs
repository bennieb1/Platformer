using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer sr;

    public Sprite cpOn, cpOff;
    
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
        if (other.CompareTag("Player"))
        {
            CheckpointController.Instance.DeactivateCheckpoints();
            sr.sprite = cpOn;
            CheckpointController.Instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        sr.sprite = cpOff;
    }
}

