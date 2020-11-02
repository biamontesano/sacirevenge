using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsSpawn : MonoBehaviour
{
     public GameObject[] npcsPrefabs;
    private Transform playerTransform;
    private float spawnX = -6.0f;
    private float npcsDistance = 45.0f;
    private int amnTilesOnScreen = 7;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag ("Jogador").transform;

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }        
    }

    void Update()
    {
        if(playerTransform.position.x > (spawnX - amnTilesOnScreen * npcsDistance))
        {
            SpawnTile();
        }
        
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(npcsPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else{
            go = Instantiate(npcsPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent (transform);
        go.transform.position = Vector3.right * spawnX;
        spawnX += npcsDistance;
        activeTiles.Add(go);
    }

    private int RandomPrefabIndex()
    {
        if(npcsPrefabs.Length <=1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, npcsPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}