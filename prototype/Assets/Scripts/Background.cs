using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Transform mytransform;
    public Vector3 direction;
    private void Start()
    {
        mytransform = GetComponent<Transform>();
        direction = new Vector3(0, 0.1f , 0);
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
            mytransform.position += direction;
        
    }
}
   

