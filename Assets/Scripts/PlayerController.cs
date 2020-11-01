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
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public float rotSpeed = 90;
    public int score;
    public GameObject Enemy;
    public bool PodeUsar;
    private Vector3 moveDirection;
    public bool Atacando;
    public float Distancia;
    public bool sugar;

    public Animator anim;

   
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Enemy = GameObject.FindWithTag("Inimigo");
        PodeUsar = true;
    }

    // Update is called once per frame
    void Update()
    {
        //**********************Movimentação Personagem***************//
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
       

        moveDirection = new Vector3(mH * moveSpeed, moveDirection.y , mV * moveSpeed);
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);

        if (controller.isGrounded)
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            else if (Input.GetAxis("Horizontal") < 0)
                transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }

        controller.Move(moveDirection * Time.deltaTime);
        //**********************Movimentação Personagem***************//
        //??
        anim.SetInteger("Score", score);

        // Skill Tornado
        if (Input.GetButtonDown("Jump") && PodeUsar == true)
        {
            Physics.IgnoreCollision(controller, Enemy.GetComponent<Collider>(), true);
            SkillDuracao();
            PodeUsar = false;
            StartCoroutine(SkillColdown(5f)); //Precisa Configurar o Tempo.
        }

        IEnumerator SkillColdown(float coldown)
        {
            yield return new WaitForSeconds(coldown);
            Physics.IgnoreCollision(controller, Enemy.GetComponent<Collider>(), false);
            PodeUsar = true;
        }


        //Animação de Ataque
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("Attack", true);
            Atacando = true;
        } else
        {
            anim.SetBool("Attack", false);
            Atacando = false;
        }

        //Animação Movimentação (A/S/W/D)
        if (mH !=  0 || mV != 0)
        {
            anim.SetBool("Movendo", true);
        }else
        {
            anim.SetBool("Movendo", false);
        }


        //SaciGarrafa - Puxa para Garrafa e Destroi o Jogador.
        Distancia = Vector3.Distance(transform.position, Enemy.transform.position);

        if (Distancia < 2 && PodeUsar == true )
        {
            sugar = true;
            StartCoroutine(Sugando());
        }
        else
        {
            sugar = false;
            anim.SetBool("Sugando?", false);
        }
    }


    // Skill Tornado 
    public void SkillDuracao()
    {
        anim.SetBool("SkillTornado", true);
        StartCoroutine(DuracaoSkill(4f)); //Precisa Configurar o Tempo.

        IEnumerator DuracaoSkill(float duracao)
        {
            yield return new WaitForSeconds(duracao);
            PodeUsar = false;
            anim.SetBool("SkillTornado", false);
        }
    }

    //Puxa para Garrafa e Destroi o Jogador.
    public IEnumerator Sugando()
    {
        anim.SetBool("Sugando?", true);
        yield return new WaitForSecondsRealtime(4); //Precisa Configurar o Tempo.
        if(sugar == true)
        {
            Destroy(gameObject);
        } else
        {
            yield break;
        }

    }


    //Destruindo Objetos.
    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (Atacando == true && objetoDeColisao.tag == "Destrutivel")
        {
            DestroyOnTrigger.Instance.hits--;
            if (DestroyOnTrigger.Instance.hits <= 0)
            {
                Destroy(objetoDeColisao.gameObject);
                GameManager.Instance.Score += DestroyOnTrigger.Instance.points;
            }
                
        }
    }


}