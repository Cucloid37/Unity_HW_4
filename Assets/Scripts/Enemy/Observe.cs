using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Observe : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private bool ItIsPlayer;
    public bool itIsPlayer => ItIsPlayer;

    #region OnTrigger
    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<NewController>())
        {
            ItIsPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NewController>())
        {
            ItIsPlayer = false;
        }
    }
    #endregion


}
