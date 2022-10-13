using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
 
   
   
    public int starScore;
    void Start()
    {
      
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            starScore += 1000;
           Destroy(gameObject);
          
        }
          
    }

}
