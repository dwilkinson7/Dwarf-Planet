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
    float distanceToDestination;

    private void FixedUpdate()
    {
        desiredLocation = Target.TransformPoint(Offset);
        distanceToDestination = (desiredLocation - transform.position).sqrMagnitude;
        transform.position = Vector3.Lerp(transform.position, desiredLocation, distanceToDestination * MoveSpeed * Time.fixedDeltaTime);
        desiredRotation = Quaternion.LookRotation((Target.position + LookatOffset) - transform.position, Target.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, RotationSpeed * Time.deltaTime);
    }
}
