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
        
       
        anim.SetInteger("Score", score);

        // Skill Tornado
        if (Input.GetButtonDown("Jump") && PodeUsar == true)
        {
            Physics.IgnoreCollision(controller, Enemy.GetComponent<Collider>(), true);
            SkillDuracao();
            PodeUsar = false;
            StartCoroutine(SkillColdown(5f));
        }

        IEnumerator SkillColdown(float coldown)
        {
            yield return new WaitForSeconds(coldown);
            Physics.IgnoreCollision(controller, Enemy.GetComponent<Collider>(), false);
            PodeUsar = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("Attack", true);
        } else
        {
            anim.SetBool("Attack", false);
        }

        //Animação Movendo (A/S/W/D)
        if (mH !=  0 || mV != 0)
        {
            anim.SetBool("Movendo", true);
        }else
        {
            anim.SetBool("Movendo", false);
        }

    }


    // Skill Tornado 
    public void SkillDuracao()
    {
        anim.SetBool("SkillTornado", true);
        StartCoroutine(DuracaoSkill(4f));

        IEnumerator DuracaoSkill(float duracao)
        {
            yield return new WaitForSeconds(duracao);
            PodeUsar = false;
            anim.SetBool("SkillTornado", false);
        }
    }


}
