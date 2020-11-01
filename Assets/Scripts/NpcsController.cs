using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{
    // public float MoveSpeed = 2;
    // private Rigidbody Enemy;
    // public GameObject Player;
    // private Vector3 Direction;
    // private float Distance;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     Enemy = GetComponent<Rigidbody>();
    //     Player = GameObject.FindWithTag("Jogador");
    // }

    // private void FixedUpdate()
    // {
    //     Direction = Player.transform.position - Enemy.transform.position;
    //     Distance = Vector3.Distance(transform.position, Player.transform.position);


    //     Quaternion NewRotation = Quaternion.LookRotation(Direction);
    //     Enemy.MoveRotation(NewRotation);

    //     if (Distance > 2 )
    //      {
    //         Movement(Direction, MoveSpeed);
    //      }
    // }

    // public void Movement(Vector3 Move, float MS)
    // {
    //     Enemy.MovePosition(Enemy.position + Move.normalized * MS * Time.deltaTime);
    // }

    public float sensorLength = 5.0f;
    public float speed = 10.0f;
    float directionValue = 1.0f;
    float turnValue = 0.0f;
    public float turnSpeed = 50.0f;
    Collider myCollider;
    void Start()
    {
        myCollider = transform.GetComponent<Collider>();
    }

    void Update()
    {
        // RaycastHit hit;
        // int flag = 0;

        //Right Sensor
        // if(Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x)))
        // {
        //     if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
        //     {
        //         return;
        //     }
        //     turnValue -= 1;
        //     flag++;
        // }

        // //Left Sensor
        // if(Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x)))
        // {
        //     if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
        //     {
        //         return;
        //     }
        //     turnValue += 1;
        //     flag++;
        // }

        // //Front Sensor
        // if(Physics.Raycast(transform.position, transform.forward, out hit, (sensorLength + transform.localScale.z)))
        // {
        //     if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
        //     {
        //         return;
        //     }

        //     if(directionValue == 1.0f)
        //     {
        //         directionValue = -1;
        //     }
        //     flag++;
        // }

        // //Back Sensor
        // if(Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.z)))
        // {
        //     if(hit.collider.tag != "Obstacle" || hit.collider == myCollider)
        //     {
        //         return;
        //     }
        //     if(directionValue == -1.0f)
        //     {
        //         directionValue = 1;
        //     }
        //     flag++;
        // }

        // if(flag == 0)
        // {
        //     turnValue = 0;
        // }

        transform.Rotate(Vector3.up * (turnSpeed * turnValue) * Time.deltaTime);

        transform.position += transform.forward * (speed*directionValue) * Time.deltaTime;

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x));
    }


}
