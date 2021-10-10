using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugForceCube : MonoBehaviour
{
    public float force = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().velocity += transform.forward * force;
        }
    }
}
