using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{

    public float MoveSpeed = 2;
    private Rigidbody Npc;
    public GameObject Player;
    private Vector3 Direction;
    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Npc = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Jogador");
    }

    private void FixedUpdate()
    {
        Direction = Player.transform.position - Npc.transform.position;
        Distance = Vector3.Distance(transform.position, Player.transform.position);


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
