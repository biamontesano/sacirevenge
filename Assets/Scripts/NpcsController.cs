using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{
    public Transform home;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(home.position);       
    }

}
