using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float PlayerHealth;
    public float playerHealth => PlayerHealth;

    [SerializeField] private HealthInSquare HP;
    [SerializeField] private float bomb;            // ��� ����� ����� ���������� � ��������� ��� ������
    [SerializeField] private Skeleton skeleton;

    private void Update()
    {
        Debug.LogError(PlayerHealth);
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PlayerHealth -= 0.2f;
            Debug.Log(PlayerHealth);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealth += 0.2f;
            Debug.Log(PlayerHealth);
        }

        if(PlayerHealth <= 0)
        {
            Destroy(gameObject);
            // ������ ����� � ���� - Game Over
        }
    }

    private void DamageSk()
    {
        PlayerHealth -= skeleton.skDamage;
        Debug.Log($"��� ������ ����� ������� �����: {skeleton.skDamage}");
        Debug.Log($"� ������ ������� ����� �������� ������: {PlayerHealth}");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Skeleton>())
        {
            Invoke(nameof(DamageSk), 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HealthInSquare>())
        {
            PlayerHealth += HP.HP;
            Destroy(other.gameObject);
            Debug.Log($"������ � ��� ������ === {PlayerHealth}");

        }

        if(other.GetComponent<BigBomb>())
        {
            bomb++;
            Destroy(other.gameObject);
            Debug.Log($"������ � ��� ���� === {bomb}");
        }
    }
}
