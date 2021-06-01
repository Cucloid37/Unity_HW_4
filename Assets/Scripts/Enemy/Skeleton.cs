using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private float ScHealth;        // �������� �����
    public float scHealth => ScHealth;

    [SerializeField] private float ScDamage;        // ���� �����
    public float skDamage => ScDamage;

    [SerializeField] BombLogic _bombDamage;
    [SerializeField] GameObject Gun;
    private bool PlayerIsNear;

    private void Update()
    {
        if(ScHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PickUp>())
        {
            PlayerIsNear = true;
            Transform transformPlayer = collision.gameObject.GetComponent<Transform>();
            StartCoroutine(Attack(transformPlayer));
        }

        if(collision.gameObject.GetComponent<BombLogic>())
        {
            ScHealth -= _bombDamage.BombDamage;
            Debug.Log($"������� �������� �����: {_bombDamage.BombDamage}, ������� ��������: {ScHealth}");
        }
    }

    private IEnumerator Attack(Transform player)
    {
        // �������� �����, ����� ���� ��������� ����
        yield return new WaitWhile(() => !PlayerIsNear);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
