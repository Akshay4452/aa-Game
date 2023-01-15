using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    [SerializeField] public GameObject pauseCanvas;
    [SerializeField] public GameObject scoreCanvas;
    // [SerializeField] public GameObject scoreText;
    // [SerializeField] public GameObject pauseButton;
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
        pauseCanvas.SetActive(true); // activate the pause menu screen over the game
        // scoreText.SetActive(false);
        // pauseButton.SetActive(false);
        scoreCanvas.SetActive(false);
    }
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        // scoreText.SetActive(true);
        // pauseButton.SetActive(true);
        scoreCanvas.SetActive(true);
    }
}
