using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredao : MonoBehaviour
{

    public Transform tile1Obj;
    public GameObject MoveSpeed;
    Vector3 _nextTileSpawn;
    public bool Cruzou;

    private void OnTriggerStay(Collider paredeColisao)
    {
        if (paredeColisao.tag == "BateuCriou")
        {
            Cruzou = true;
            StartCoroutine(spawnTitle());
        } else
        {
            Cruzou = false;
        }
    }

    IEnumerator spawnTitle()
    {
        yield return new WaitForSecondsRealtime(1);
        if (Cruzou == true)
        {
            _nextTileSpawn.x += 146.5f;
            _nextTileSpawn.y = 14;
            Instantiate(tile1Obj, _nextTileSpawn, tile1Obj.rotation);
            Cruzou = false;
        } else
        {
            yield break;
        }
    }
}
