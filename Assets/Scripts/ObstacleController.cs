using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    bool moving = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(moving)
                this.transform.Translate(0, 0, 0);
            else
                this.transform.Translate(1, 0, 0);
            
            moving = !moving;
        }
        
    }
}
