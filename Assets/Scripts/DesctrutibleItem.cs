using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesctrutibleItem : MonoBehaviour
{
    public int hits = 1;
    public int points = 5;

    
    public static DesctrutibleItem Instance { get; private set; }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
