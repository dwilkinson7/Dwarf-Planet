using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGravity : MonoBehaviour {
    [SerializeField] Rigidbody rigidbody;

    public bool OrientToGround;

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

    private void Update()
    {
        if (OrientToGround)
        {
            Vector3 fwd = Vector3.ProjectOnPlane(transform.forward, transform.position);
            transform.rotation = Quaternion.LookRotation(fwd, transform.position.normalized);
        }
    }
}
