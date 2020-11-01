using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject objToDestroy;
    // public GameObject effect;
    bool canDestroy = false;

    public int hits;
    public int points;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E) && canDestroy)
        {
            hits--;
            if (hits <= 0)
            {
                GameManager.Instance.Score += points;
                // Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);
                Destroy(objToDestroy);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jogador")
        {
         canDestroy = true;   
        }
    }
}
