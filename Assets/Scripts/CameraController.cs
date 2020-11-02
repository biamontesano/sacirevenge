using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private GameObject Player;
    public Transform targetCrianca;

    public bool useOffsetValues;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Jogador");
        if (!useOffsetValues) 
        { 
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Jogador") == true)
        {
            transform.position = target.position - offset;
            transform.LookAt(target);
        } else
        {
            transform.LookAt(targetCrianca);
        }
    }
}
