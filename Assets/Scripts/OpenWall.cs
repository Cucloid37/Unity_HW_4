using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    [SerializeField] private GameObject _openWall;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.GetComponent<CapsuleCollider>() && Input.GetKey(KeyCode.R))
        {
            Destroy(_openWall);
        }
    }

}
