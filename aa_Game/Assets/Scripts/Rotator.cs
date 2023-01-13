using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static float rotationSpeed = 100f; // used it as singleton
    ScoreHandler scoreHandler;
    
    void Start() 
    {
        scoreHandler = GetComponent<ScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        scoreHandler.scoreUpdate();
    }
}
