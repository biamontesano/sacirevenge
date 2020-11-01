using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcsController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 200f;

    bool _isWandering = false;
    bool _isRotatingLeft = false;
    bool _isRotatingRight = false;
    bool _isWalking = false;

    void Start()
    {
        
    }
    void Update()
    {
        if(_isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if(_isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if(_isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(_isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        _isWandering = true;

        yield return new WaitForSeconds(walkWait);
        _isWalking = true;
        yield return new WaitForSeconds(walkTime);
        _isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR == 1)
        {
            _isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            _isRotatingRight = false;
        }

        if(rotateLorR == 1)
        {
            _isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            _isRotatingLeft = false;
        }
        _isWandering = false;
    }

}
