using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody Meubody;
    private Movimentacao MovimentaPersonagem;
    public float CooldownSkill;
    public float DuracaoTornado;
    public float GarrafaTime;
    public GameObject Enemy;
    public bool Colisao;
    private Vector3 moveDirection;
    public LayerMask Mascarachao;


    //Escondido no Inspector

    public Animator anim;
    [HideInInspector]
    public bool Atacando;
    [HideInInspector]
    public bool sugar;
    [HideInInspector]
    public bool PodeUsar;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public float Distancia;
    //**********************


    // Start is called before the first frame update
    void Start()
    {
        Meubody = GetComponent<Rigidbody>();
        Enemy = GameObject.FindWithTag("Inimigo");
        MovimentaPersonagem = GetComponent<Movimentacao>();
        PodeUsar = true;
        Colisao = false;
        //Physics.IgnoreCollision(ColliderPlayer, Enemy.GetComponent<Collider>(), Colisao);
    }

    // Update is called once per frame
    void Update()
    {
        //**********************Movimentação Personagem***************//
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(eixoX, 0, eixoZ);

        MovimentaPersonagem.Movimentar(moveDirection, moveSpeed);
        MovimentaPersonagem.RotacionarJogador(Mascarachao);

        //**********************Movimentação Personagem***************//
        //??

        // Skill Tornado
        if (Input.GetKey(KeyCode.E) && PodeUsar == true)
        {
            Colisao = true;
            SkillDuracao();
            PodeUsar = false;
            moveSpeed = 20f;
            StartCoroutine(SkillCooldown(CooldownSkill)); //Precisa Configurar o Tempo.
        }

        IEnumerator SkillCooldown(float Cooldown)
        {
            yield return new WaitForSeconds(Cooldown);
            moveSpeed = 6f;
            PodeUsar = true;
        }


        //Animação de Ataque
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
            Atacando = true;
        }
        else
        {
            anim.SetBool("Attack", false);
            Atacando = false;
        }

        //Animação Movimentação (A/S/W/D)
        if (eixoX != 0 || eixoZ != 0)
        {
            anim.SetBool("Movendo", true);
        }
        else
        {
            anim.SetBool("Movendo", false);
        }


        //SaciGarrafa - Puxa para Garrafa e Destroi o Jogador.
        Distancia = Vector3.Distance(transform.position, Enemy.transform.position);

        if (Distancia < 3.4 && PodeUsar == true)
        {
            sugar = true;
            StartCoroutine(Sugando());
            moveSpeed = 4;
        }
        else
        {
            sugar = false;

            anim.SetBool("Sugando?", false);
            moveSpeed = 6;
        }
    }

    private void FixedUpdate()
    {

    }

    // Skill Tornado 
    public void SkillDuracao()
    {
        anim.SetBool("SkillTornado", true);
        StartCoroutine(DuracaoSkill(DuracaoTornado)); //Precisa Configurar o Tempo.
        IEnumerator DuracaoSkill(float duracao)
        {
            yield return new WaitForSecondsRealtime(duracao);
            PodeUsar = false;
            Colisao = false;
            anim.SetBool("SkillTornado", false);
        }
    }

    //Puxa para Garrafa e Destroi o Jogador.
    public IEnumerator Sugando()
    {
        anim.SetBool("Sugando?", true);
        yield return new WaitForSecondsRealtime(GarrafaTime); //Precisa Configurar o Tempo.
        if (sugar == true)
        {
            Destroy(gameObject);
        }
        else
        {
            yield break;
        }

    }
}