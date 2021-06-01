using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float maxDist = 7.0f;
    private float _distance;
    private Vector3 current;
    

    private void Start()
    {
        current = new Vector3();

    }

    private void FixedUpdate()
    {
        
        transform.LookAt(_player.transform);
        MoveCamera();
        
    }

    private void MoveCamera()
    {
        
        _distance = Mathf.Sqrt((transform.position - _player.transform.position).sqrMagnitude);
        Vector3 targetDir = _player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(current, targetDir, 2.0f * Time.deltaTime, Vector3.Magnitude(current));
        Debug.DrawRay(transform.position, newDir, Color.red);
        
        if(_distance > maxDist)
        {
            transform.Translate(newDir * _speed * Time.deltaTime);
        }


    }

}
