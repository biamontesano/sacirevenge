using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int hits;
    public int points;
    public GameObject destroyedVersion;
    public GameObject Player;
    private float playerdistance;

    void Start()
    {
        Player = GameObject.FindWithTag("Jogador");
    }

    private void OnMouseDown()
    {
        playerdistance = Vector3.Distance(transform.position, Player.transform.position);

        if(playerdistance < 3)
        {
            hits--;
            if(hits < 0)
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                GameManager.Instance.Score += points;
                Destroy(gameObject);
            }
        }
    }


}
