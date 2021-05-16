using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private bool ItIsPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == _player)
        {
            ItIsPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == _player)
        {
            ItIsPlayer = false;
        }
    }

    private void Update()
    {
        Debug.Log(ItIsPlayer);
        if(ItIsPlayer)
        {
            Debug.Log("Oh, eh! I'm see you");
        }
    }
}
