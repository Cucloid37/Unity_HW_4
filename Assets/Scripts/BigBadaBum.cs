using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadaBum : MonoBehaviour
{

    [SerializeField] private int _damage;

    private void Update()
    {
        
    }
    public void Bum(GameObject en)
    {
        var collider = en.GetComponent<Collider>(); // �������� ��������� �����
        OnTriggerEnter(collider); // �������� �������, ��������� ��������� �����
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            Debug.Log($"�������� {_damage} �����");
            Destroy(gameObject);
        }
    }

}
