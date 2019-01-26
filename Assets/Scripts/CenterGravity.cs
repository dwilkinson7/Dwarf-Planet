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
            //float eulerY = transform.localEulerAngles.y;
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.position.normalized);
            //transform.rotation = Quaternion.LookRotation(transform.forward, transform.position);
            //transform.up = transform.position;
            //var eulerAngles = transform.localEulerAngles;
            //eulerAngles.y = eulerY;
            //transform.localEulerAngles = eulerAngles;

            Vector3 fwd = Vector3.ProjectOnPlane(transform.forward, transform.position);
            Debug.DrawRay(transform.position, fwd, Color.blue, 0.5f);
            //transform.rotation.SetLookRotation(fwd, transform.position.normalized);
            transform.rotation = Quaternion.LookRotation(fwd, transform.position.normalized);
            Debug.DrawRay(transform.position, transform.forward, Color.red, 0.5f);
            Debug.DrawRay(transform.position, transform.up, Color.white, 0.5f);
        }
    }
}
