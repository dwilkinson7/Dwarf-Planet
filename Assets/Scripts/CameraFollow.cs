using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float RotationSpeed = 1f;
    public Transform Target;
    public Vector3 Offset;
    public Vector3 LookatOffset;

    Quaternion desiredRotation;
    Vector3 desiredLocation;
    Vector3 _toDestination;

    private void FixedUpdate()
    {
        desiredLocation = Target.TransformPoint(Offset);
        _toDestination = desiredLocation - transform.position;
        transform.position += Vector3.ClampMagnitude(_toDestination, MoveSpeed);
        desiredRotation = Quaternion.LookRotation((Target.position + LookatOffset) - transform.position, Target.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, RotationSpeed * Time.fixedDeltaTime);
    }
}
