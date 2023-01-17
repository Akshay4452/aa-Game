using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    [SerializeField] public GameObject scoreCanvas;
    // List<int> MaxScores = new List<int>();
    // int maxLevels = 5;
    
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
    public void ResumeGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
    }
}
