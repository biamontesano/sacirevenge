using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{

    public Transform[] target;
    public float speed = 5;
    private int current;

    void Start()
    {

    }

    void Update()
    {
        if(transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
        }
    }
}
