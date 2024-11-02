using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        MenuManager.Instance.StartGame();
    }
    
    public void QuitGame()
    {
        MenuManager.Instance.QuitGame();
    }
}
