using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float MoveSpeed = 2;
    private Rigidbody Enemy;
    public GameObject Player;
    private Vector3 Direction;
    private float Distance;
    [HideInInspector]
    public Animator animInimigo; 
    public Material[] randomMaterials;

    private Renderer inimigos;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Jogador");
        animInimigo = GetComponent<Animator>();
        CriancasRandom();
    }

    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Jogador") == true)
        {
            Direction = Player.transform.position - Enemy.transform.position;
            Distance = Vector3.Distance(transform.position, Player.transform.position);


            Quaternion NewRotation = Quaternion.LookRotation(Direction);
            Enemy.MoveRotation(NewRotation);

            if (Distance > 2.4)
            {
                Movement(Direction, MoveSpeed);
                animInimigo.SetBool("Puxando", false);
            }
            else
            {
                animInimigo.SetBool("Puxando", true);
            }


        }else
        {
            Time.timeScale = 0;
        }
    }

    public void Movement(Vector3 Move, float MS)
    {
        Enemy.MovePosition(Enemy.position + Move.normalized * MS * Time.deltaTime);
    }

    void CriancasRandom()
    {
        for( int i = 2; i < 7; i++ )
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        // transform.GetChild(3).gameObject.SetActive(false);
        // transform.GetChild(4).gameObject.SetActive(false);
        // transform.GetChild(5).gameObject.SetActive(false);
        // transform.GetChild(6).gameObject.SetActive(false);
        
        inimigos = GetComponent<Renderer>();

        inimigos.material = randomMaterials[Random.Range(0, randomMaterials.Length)];
        
        int gerarTipoCrianca = Random.Range(2, 6);
        
        transform.GetChild(gerarTipoCrianca).gameObject.SetActive(true);
    }

}
