using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static Rotator instance; // Rotator is now singleton
    public float rotationSpeed = 100f;
    
    public float spawnDelay = 0.5f;
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] public Vector2 pinSpawnPosition = new Vector2(0f, -4f);
    [SerializeField] private Vector2 spinSpeed = new Vector2(100f, 500f);
    
    int[] spinDirection = new int[] {-1, 1};

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
        scoreHandler = GetComponent<ScoreHandler>();
        // Instantiate the pin when game starts
        SpawnPin();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        // setting random speed after dart hits the rotator 
        rotationSpeed = Random.Range(spinSpeed.x, spinSpeed.y);
        rotationSpeed = -1 * rotationSpeed;
        Invoke(nameof(SpawnPin), spawnDelay);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    public void SpawnPin()
    {
        GameObject pinInstance = Instantiate(pinPrefab, pinSpawnPosition, Quaternion.identity);
    }
}
