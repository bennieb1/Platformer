using UnityEngine;

public class CheckpointController : Singelton<CheckpointController>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Checkpoint[] checkpoints;

    public Vector3 spawnPoint;
    void Start()
    {

        checkpoints = FindObjectsOfType<Checkpoint>();

        spawnPoint = PlayerController.Instance.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DeactivateCheckpoints()
    {

        for (int i = 0; i < checkpoints.Length; i++)
        {

            checkpoints[i].ResetCheckpoint();

        }
        
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint )
    {
        spawnPoint = newSpawnPoint;
    }

}
