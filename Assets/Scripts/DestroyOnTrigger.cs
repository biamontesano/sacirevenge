using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    // public GameObject effect;

    public int hits;
    public int points;

    
    public static DestroyOnTrigger Instance { get; private set; }

    void Start()
    {
        Instance = this;
        
    }

    void Update()
    {
        
    }

}
