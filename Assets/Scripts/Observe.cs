using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Observe : MonoBehaviour
{
    [SerializeField] private Transform _player;
    protected private bool ItIsPlayer;

    #region OnTrigger
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
    #endregion

    private void Update()
    {
        if(ItIsPlayer)
        {
            Debug.Log("Oh, eh! I'm see you");
            NavMeshAgent_1.Chase(_player);
            
            if(!ItIsPlayer)
            {
                NavMeshAgent_1.Stop();
            }
        }

    }
}
