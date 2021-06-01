using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private float ScHealth;        // здоровье врага
    public float scHealth => ScHealth;

    [SerializeField] private float ScDamage;        // урон врага
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
            Debug.Log($"Скелету нанесено урона: {_bombDamage.BombDamage}, остлось здоровья: {ScHealth}");
        }
    }

    private IEnumerator Attack(Transform player)
    {
        // анимация удара, после чего наносится урон
        yield return new WaitWhile(() => !PlayerIsNear);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
