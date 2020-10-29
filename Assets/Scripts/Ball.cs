using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    Renderer _renderer;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _renderer = this.GetComponent<Renderer>();

        _velocity = new Vector3(10f, 10f, 0f);
        _rigidbody.AddForce(_velocity, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        if(!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
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
