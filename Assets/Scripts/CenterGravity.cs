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
        rigidbody.AddForce(transform.position.normalized * -9.81f);

        if (OrientToGround)
        {
            transform.eulerAngles += Quaternion.FromToRotation(transform.up, transform.position.normalized).eulerAngles;
            //transform.rotation = Quaternion.LookRotation(transform.forward, transform.position);
            //transform.up = transform.position;
        }
    }
}
