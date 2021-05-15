using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    private Transform push;

    private void Start()
    {
        push = transform.GetChild(0).transform.GetChild(1);

        Debug.LogWarning(push.GetType());
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.LogWarning("Соприкосновение произошло");

        if (other.GetComponent<CapsuleCollider>())
        {
            //push.transform.rotation = Quaternion.LookRotation(push.transform.position, other.transform.position);

            //push.transform.rotation = Quaternion.FromToRotation(push.transform.position, other.transform.position);

            // push.transform.rotation = Quaternion.Euler(0, (Quaternion.LookRotation(push.transform.position, other.transform.position), 0);

            Vector3 targetDir = other.transform.position - push.transform.position;
            Vector3 newDir = Vector3.RotateTowards(push.transform.forward, targetDir, 2.0f * Time.deltaTime, 5.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            push.transform.rotation = Quaternion.LookRotation(newDir);
        }

    }
   
}
