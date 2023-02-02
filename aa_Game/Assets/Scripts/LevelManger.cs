using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    public static LevelManger LMInstance;
    int lastLevel = 2; // scene index of last level
    [SerializeField] public int[] maxPinsInLevel = new int[3];
    [SerializeField] public float[] rotatorSize = new float[3];
    [SerializeField] public float[] rotationSpeedInLevel = new float[3];
    public int currentLevel = 0;
    public int nextLevelIndex;
    void Awake()
    {
        if(LMInstance == null)
        {
            LMInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevelIndex = currentLevel + 1;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        if(!Rotator.instance.isGameOver) 
        {
            if(currentLevel != lastLevel)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            } 
        }
    }
    void Update()
    {
        if(!(SceneManager.GetActiveScene().name == "GameOver"))
            if(Rotator.instance.pinsHit == maxPinsInLevel[currentLevel])
            {
                FindObjectOfType<GameManager>().LevelComplete();
                Invoke(nameof(LoadNextLevel), 0.5f);
            }
    }
}
