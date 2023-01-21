using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    public float shootSpeed = 20f;
    public float cameraZoom = 3.5f;
    public float slowMotionSpeed = 0.3f;
    public Rigidbody2D rb;
    
    bool isScored = false;
    private Camera mainCamera;
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // checks if user has touched the screeen
        {
            Touch touch = Input.GetTouch(0);
            if(!isScored)
            {
                if(touch.phase == UnityEngine.TouchPhase.Began)
                {
                    {
                        // rb.MovePosition(rb.position + Vector2.up * shootSpeed * Time.deltaTime);
                        rb.velocity = new Vector2(0f, shootSpeed);
                    }   
                }          
            }  
        }     
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Rotator")
        {
            transform.parent = other.gameObject.transform;
            rb.velocity = Vector2.zero;
            Rotator.instance.scoreHandler.scoreUpdate();
            FindObjectOfType<AudioManager>().Play("PlayerScored");
            isScored = true;
        }
        else if(other.tag == "Pin")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<GameManager>().EndGame();
            Invoke(nameof(GameOver), 0.5f);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
