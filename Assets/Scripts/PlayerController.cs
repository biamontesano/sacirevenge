using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public float rotSpeed = 90;
    public int score;

    private Vector3 moveDirection;

    public Animator anim;

   
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();
        moveSpeed = moveSpeed;
        
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
        
        anim.SetBool("Attack", Input.GetButtonDown("Jump"));
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        anim.SetInteger("Score", score);

    }    
    
    void OnCollisionEnter(Collision collision){
        ReflectProjectile(_rigidbody, collision.contacts[0].normal);
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {    
        _velocity = Vector3.Reflect(_velocity, reflectVector);
        _rigidbody.velocity = _velocity;
    }

}
