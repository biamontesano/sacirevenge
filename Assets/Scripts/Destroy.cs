using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int hits;
    public int points;
    public GameObject destroyedVersion;

    private void OnMouseDown()
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
