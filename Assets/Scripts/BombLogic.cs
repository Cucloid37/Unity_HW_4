using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BombLogic : MonoBehaviour
{

    [SerializeField] private int damage;
    public int BombDamage => damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Skeleton>())
        {
            Debug.Log($"Нанесено {damage} урона");
            Destroy(gameObject);
        }
    }

}
