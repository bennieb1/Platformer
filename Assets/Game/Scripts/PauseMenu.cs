using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Resume()
    {
        MenuManager.Instance.TogglePause();
    }
    
    public void MainMenu()
    {
        MenuManager.Instance.MainMenu();
    }
    
    public void QuitGame()
    {
        MenuManager.Instance.QuitGame();
    }
    
    public void Restart()
    {
        MenuManager.Instance.Restart();
    }
    
    public void LevelSelect()
    {
        MenuManager.Instance.LevelSelect();
    }
    
    
}
