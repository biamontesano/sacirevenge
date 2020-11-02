using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject CriancaInimigo;
    private float contadorDeTempo = 0;
    public float tempoSpawn = 0;


    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        contadorDeTempo += Time.deltaTime;

        if (contadorDeTempo >= tempoSpawn)
        {
            Instantiate(CriancaInimigo, transform.position, transform.rotation);
            contadorDeTempo = 0;
        }
    }
}
