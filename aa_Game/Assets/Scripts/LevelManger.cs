using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    [SerializeField] public GameObject scoreCanvas;
    // List<int> MaxScores = new List<int>();
    // int maxLevels = 5;
    public static bool isPauseScreenActive = false;
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0.1f; // play game is slow motion in background
        scoreCanvas.SetActive(false);
        isPauseScreenActive = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        isPauseScreenActive = false;
    }
}
