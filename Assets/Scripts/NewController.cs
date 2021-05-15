using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jampForce;
    [SerializeField] private Vector3 _move;
    [SerializeField] private GameObject _camera;
    private bool isGround;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveLogic();
        JumpLogic();
    }

    private void MoveLogic()
    {
        _move.x = Input.GetAxis("Horizontal");
        _move.z = Input.GetAxis("Vertical");

        transform.Translate(_move * _speed * Time.deltaTime, Camera.main.transform);
        Quaternion rotation = Quaternion.LookRotation(_move);
        transform.rotation = rotation;
    }

    private void JumpLogic()
    {
        if(isGround)
        {
            if(Input.GetAxis("Jump") > 0)
            {
                transform.Translate(transform.up * _jampForce);
               // _rb.AddForce(transform.up * _jampForce);
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider);
        Debug.Log(collision.collider.GetComponent<Collider>());
        if (collision.collider.GetComponent<Collider>())
        {
            isGround = true;
        }
    }
}
