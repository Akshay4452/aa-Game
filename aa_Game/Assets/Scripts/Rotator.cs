using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{
    public static Rotator instance; // Rotator is now singleton
    // public float rotationSpeed = 100f;  
    public float spawnDelay = 0.05f;
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] public Vector2 pinSpawnPosition = new Vector2(0f, -4f);
    // [SerializeField] private Vector2 spinSpeed = new Vector2(100f, 500f);
    float rotorScale, rotorSpeed; // scale of rotor in each level, speed of rotor in current level
    public int pinsHit = 0;

    [HideInInspector]
    public ScoreHandler scoreHandler;
    public bool isGameOver = false;
    void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start() 
    {
        rotorScale = LevelManger.LMInstance.rotatorSize[LevelManger.LMInstance.currentLevel];
        // getting value of rotor scale for current level
        rotorSpeed = LevelManger.LMInstance.rotationSpeedInLevel[LevelManger.LMInstance.currentLevel];
        // getting value of rotor speed for current level
        transform.localScale = new Vector3(rotorScale,rotorScale,1);
        scoreHandler = GetComponent<ScoreHandler>();
        // Instantiate the pin when game starts
        SpawnPin();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        // setting random speed after dart hits the rotator 
        // rotationSpeed = Random.Range(spinSpeed.x, spinSpeed.y);
        Invoke(nameof(SpawnPin), spawnDelay);  
        pinsHit++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotorSpeed * Time.deltaTime);
    }
    public void SpawnPin()
    {
        GameObject pinInstance = Instantiate(pinPrefab, pinSpawnPosition, Quaternion.identity);
    }
}
