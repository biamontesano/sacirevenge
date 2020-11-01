﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform tile1Obj;
    Vector3 _nextTileSpawn;

    public Transform desctructibleItemOneObj;
    Vector3 _nextDesctructibleItemOneSpawn;
    int _randZ;
    public Transform desctructibleItemTwoObj;
    Vector3 _nextDesctructibleItemTwoSpawn;
    public Transform desctructibleItemThreeObj;
    Vector3 _nextDesctructibleItemThreeSpawn;
    
    public Transform npcObj;
    Vector3 _nextNpcSpawn;
    
    
    public Transform npcHomeObj;
    Vector3 _nextNpcHomeSpawn;
    
    int _randChoice;

    void Start()
    {
        StartCoroutine(spawnTile());
    }

    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);

        // Repete itemOne e cenário
        _randZ = Random.Range(-1, 2);
        _nextDesctructibleItemOneSpawn = _nextTileSpawn;
        _nextDesctructibleItemOneSpawn.y = -6.69f;
        _nextDesctructibleItemOneSpawn.z = _randZ;
        Instantiate(tile1Obj, _nextTileSpawn, tile1Obj.rotation);
        // Instantiate(npcHomeObj, _nextNpcHomeSpawn, npcHomeObj.rotation);
        Instantiate(desctructibleItemOneObj, _nextDesctructibleItemOneSpawn, desctructibleItemOneObj.rotation);
        
        // Repete itemTwo
        _nextTileSpawn.x += 48;
        _randZ = Random.Range(-1, 2);
        _nextDesctructibleItemTwoSpawn.x = _nextTileSpawn.x;
        _nextDesctructibleItemTwoSpawn.y = -6;
        _nextDesctructibleItemTwoSpawn.z = _randZ;
        Instantiate(tile1Obj, _nextTileSpawn, tile1Obj.rotation);
        // Instantiate(npcHomeObj, _nextNpcHomeSpawn, npcHomeObj.rotation);
        Instantiate(desctructibleItemTwoObj, _nextDesctructibleItemTwoSpawn, desctructibleItemTwoObj.rotation);
        
        // Repete itemThree
        if(_randZ == 0)
        {
            _randZ = 1;
        }
        else
        if(_randZ == 1)
        {
            _randZ = -1;
        }
        else
        {
            _randZ = 0;
        }

        _nextDesctructibleItemThreeSpawn.x = _nextTileSpawn.x;
        _nextDesctructibleItemThreeSpawn.y = -6.56f;
        _nextDesctructibleItemThreeSpawn.z = _randZ;
        Instantiate(desctructibleItemThreeObj, _nextDesctructibleItemThreeSpawn, desctructibleItemThreeObj.rotation);
        
        // Repete NPCs        
        if(_randZ == 0)
        {
            _randZ = 1;
        }
        else
        if(_randZ == 1)
        {
            _randZ = -1;
        }
        else
        {
            _randZ = 0;
        }

        _nextNpcSpawn.x = _nextTileSpawn.x;
        _nextNpcSpawn.y = -6.38f;
        _nextNpcSpawn.z = _randZ;
        Instantiate(npcObj, _nextNpcSpawn, npcObj.rotation);

        _nextTileSpawn.x += 48;
        StartCoroutine(spawnTile());
    }
}