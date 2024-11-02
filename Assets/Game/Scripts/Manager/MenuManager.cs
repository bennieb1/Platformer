using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singelton<MenuManager>
{
    [SerializeField] private GameObject player;
    [SerializeField] private string mainMenu;
    [SerializeField] private string nextLevel;
    [SerializeField] private string levelSelect;
    [SerializeField] private GameObject pauseMenu;
    
    public bool isPaused;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1;

    }
    
    public void GameOver()
    {
     
        
        
    }
    
    public void LevelComplete()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
        
    }
    
    public void LevelEnd()
    {
        
    }
    
    public void TogglePause()
    {
        // Pause the game
        
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        
        
        
        
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1;
    }
    
    
}
