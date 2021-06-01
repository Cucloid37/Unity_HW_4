using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jampForce;
    [SerializeField] private Vector3 _move;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _bomb;
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
        BombLogic();
    }

    private void BombLogic()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(_bomb, _rb.position, Quaternion.identity);
        }
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
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGround)
            {
                _rb.AddForce(transform.up * _jampForce);
            }   
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Collider>())
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
            isGround = false;
    }
}
