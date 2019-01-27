using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGravity : MonoBehaviour {
    [SerializeField] Rigidbody rigidbody;

    private void Awake()
    {
        if (!rigidbody)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(transform.position.normalized * -9.81f, ForceMode.Acceleration);
    }
}
