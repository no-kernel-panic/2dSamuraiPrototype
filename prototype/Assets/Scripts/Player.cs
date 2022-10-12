using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    public Animator animator;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    

    
    void Update()
    {
        /// <summary>
        ///   <para>Returns the value of the virtual axis identified by axisName.</para>
        /// </summary>
        /// <param name="axisName"></param>
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Debug.Log(Input.GetAxis("Vertical"));
        Jump();
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
        transform.position += movement * Time.deltaTime * moveSpeed;
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
             isGrounded = true;
    }
   
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
             isGrounded = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 650f), ForceMode2D.Impulse);
        }
    }
    
    
    
}
