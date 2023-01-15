using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    public float shootSpeed = 20f;
    public Rigidbody2D rb;
    bool isHit = false;
    private Camera mainCamera;
    private float touchableScreen = 0.8f;
        
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
            if(!isHit)
            {
                if(touch.position.y <= touchableScreen * Screen.height) 
                {
                    // if touch is in lower half of screen then only fire darts to rotator
                    // this condition is used for separating pause button touch and dart fire touch
                    if(touch.phase == UnityEngine.TouchPhase.Began)
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
            Rotator.rotationSpeed = -Rotator.rotationSpeed;
            isHit = true;
        }
        else if(other.tag == "Pin")
        {
            mainCamera.backgroundColor = Color.red;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
