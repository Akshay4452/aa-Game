using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public static GameManager instance; // singleton
    public Animator animator;
    public void EndGame()
    {
        animator.SetTrigger("GameOver");
    }
    public void LevelComplete()
    {
        animator.SetTrigger("LevelComplete");
    }
}
