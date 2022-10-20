using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    public Animator animator;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    Rigidbody2D _rigidbody;
    private Vector3 floorvec;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
     
        Jump();
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
        transform.position += movement * (Time.deltaTime * moveSpeed);
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
             isGrounded = true;
    }
   
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            StartCoroutine(Fade(other.gameObject));
        }


    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true )
        {
          _rigidbody.AddForce(new Vector2(0f, 650f), ForceMode2D.Impulse);
        }
    }
    
    
    
    IEnumerator Fade(GameObject obj)
    {
        Vector3 scales = obj.transform.localScale;
        for (float scale = 1f; scale >= 0; scale -= 0.01f)
        {
            scales.x = scale;
            scales.y = scale;
            obj.transform.localScale = scales;
            yield return null;
        }
    }
    
    
    
}
