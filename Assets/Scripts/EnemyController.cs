using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed = 2;
    private Rigidbody Enemy;
    public GameObject Player;
    private Vector3 Direction;
    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Jogador");
    }

    private void FixedUpdate()
    {
        Direction = Player.transform.position - Enemy.transform.position;
        Distance = Vector3.Distance(transform.position, Player.transform.position);


        Quaternion NewRotation = Quaternion.LookRotation(Direction);
        Enemy.MoveRotation(NewRotation);

        if (Distance > 2 )
         {
            Movement(Direction, MoveSpeed);
         }
    }

    public void Movement(Vector3 Move, float MS)
    {
        Enemy.MovePosition(Enemy.position + Move.normalized * MS * Time.deltaTime);
    }

}
