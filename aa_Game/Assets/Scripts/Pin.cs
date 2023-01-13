using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pin : MonoBehaviour
{
    public float shootSpeed = 20f;
    public Rigidbody2D rb;
    bool isHit = false;
    
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // checks if user has touched the screeen
        {
            Touch touch = Input.GetTouch(0);
            if(!isHit)
            {
                if(touch.phase == UnityEngine.TouchPhase.Began)
                {
                    // rb.MovePosition(rb.position + Vector2.up * shootSpeed * Time.deltaTime);
                    rb.velocity = new Vector2(0f, shootSpeed);
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
    }
}
