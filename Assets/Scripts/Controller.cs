using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed; // �������� ��������, � � ���������� ���������
    [SerializeField] private float _jumpForce; // ���� ������
    [SerializeField] private Vector3 _direction; // ����������� ��������
    [SerializeField] private GameObject _bomb;

    private Rigidbody _rb; 
    private bool _isGrounded;
   
    private void Start()
    {    
        _rb = GetComponent<Rigidbody>();

        print(_isGrounded);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Vector3 VectorBomb = new Vector3();
            VectorBomb = _rb.position;
            Instantiate(_bomb, VectorBomb, Quaternion.identity);
            Debug.Log($"������� ����: {_rb.position}");
            Debug.Log($"������: {_direction}");
            Debug.Log($"��������� �������: {gameObject.transform}");
        }
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        MoveLogic();
        JumpLogic();


    }

    private void MoveLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * _speed * Time.fixedDeltaTime);


    }

    private void JumpLogic()
    {
        var x = Input.GetAxis("Jump");
        Debug.Log(x);
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(transform.up * _jumpForce);
                
            }
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        Debug.Log("Yes!");
        if (collision.gameObject.GetComponent<Collider>())
        {
            _isGrounded = value;
        }
    }

}
