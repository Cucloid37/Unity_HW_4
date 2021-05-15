using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private GameObject _pointEnd;
    private bool ItIsBomb;
    private Transform _pointE;

    private void Start()
    {
        _pointE = _pointEnd.GetComponent<Transform>();            
        Debug.Log($"�����, � ������� �� ����� ������ {_pointE.position}");
    }

    private void Update()
    {
        #region ItIsBomb???
        if (ItIsBomb)
        {
            BigBadaBum f = new BigBadaBum(); // ������� ��������� ������ �����
            f.Bum(gameObject); // � �������� � ������� ������ �����
            Debug.Log($"����� ���������? {ItIsBomb}! �������� {_health} ��������!");
        }
        #endregion

        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointE.position, 0.2f * Time.deltaTime);
        
    }

    // ��� ������������ � ������ ���������� ���������� ���������� ItIsBomb
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            ItIsBomb = true;
        }
    }

    public void Hurt(int damage)
    {
        print("Ouch: " + damage);
        Debug.Log($"����� ���������? {ItIsBomb}! �������� {_health} ��������!");

        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
