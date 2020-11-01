using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{

    public float MoveSpeed = 2;
    private Rigidbody Npc;
    public GameObject Point;
    private Vector3 Direction;
    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Npc = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Direction = Point.transform.position - Npc.transform.position;
        Distance = Vector3.Distance(transform.position, Point.transform.position);


        Quaternion NewRotation = Quaternion.LookRotation(Direction);
        Npc.MoveRotation(NewRotation);

        if (Distance > 2 )
         {
            Movement(Direction, MoveSpeed);
         }
    }


    public void Movement(Vector3 Move, float MS)
    {
        Npc.MovePosition(Npc.position + Move.normalized * MS * Time.deltaTime);
    }

}
