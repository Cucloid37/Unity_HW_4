using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _look;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    private float _distance;
    private void Start()
    {
        _look = transform.position;
    }

    private void Update()
    {
       
       // Quaternion IamSeeYou = Quaternion.LookRotation(_look, _player.transform.position);

        transform.LookAt(_player.transform);
        MoveCamera();

       // transform.rotation = Quaternion.LookRotation(newDir);    
    }

    private void MoveCamera()
    {
        _distance = Mathf.Sqrt((transform.position - _player.transform.position).sqrMagnitude);
        Vector3 targetDir = transform.position - _player.transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 2.0f * Time.deltaTime, _distance);
        Debug.DrawRay(transform.position, newDir, Color.red);
        

        
       // Debug.LogWarning(_distance);

        if (_distance > 7.0f)
        {
            transform.Translate(newDir * _speed * Time.deltaTime);
        }
    }

}
