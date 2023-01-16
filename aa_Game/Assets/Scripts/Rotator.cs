using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static float rotationSpeed = 100f; // used it as singleton
    ScoreHandler scoreHandler;
    public float spawnDelay = 0.5f;
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] public Vector2 pinSpawnPosition = new Vector2(0f, -4f);
    
    void Start() 
    {
        scoreHandler = GetComponent<ScoreHandler>();
        // Instantiate the pin when game starts
        SpawnPin();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {   
        scoreHandler.scoreUpdate();
        Invoke(nameof(SpawnPin), spawnDelay);  
    }
    public void SpawnPin()
    {
        GameObject pinInstance = Instantiate(pinPrefab, pinSpawnPosition, Quaternion.identity);
    }
}
