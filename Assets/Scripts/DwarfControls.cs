using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class DwarfControls : MonoBehaviour
{
    public float MoveSpeed = 6.0f;
    public float TurnSpeed = 10f;
    public float JumpStrength = 8.0f;
    public float FlapStrength = 8.0f;
    public bool OrientToGround;
    private Vector3 moveDirection = Vector3.zero;

    [Header("Components")]
    public Rigidbody rigidbody;
    public Animator dwarfAnimator;

    void Update()
    {
        /* Movement */
        moveDirection = (Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection.normalized * MoveSpeed * Time.deltaTime;
        if (moveDirection.magnitude > 0)
        {
            dwarfAnimator.SetBool("Moving", true);
        }
        else
        {
            dwarfAnimator.SetBool("Moving", false);
        }

        if (Input.GetButtonDown("Jump") && CanJump)
        {
            var up = transform.position.normalized;
            if (Physics.Raycast(transform.position + (up * 0.1f), -up, 0.2f, ~LayerMask.GetMask("Player"), QueryTriggerInteraction.Ignore))
            {
                dwarfAnimator.SetTrigger("Jumping");
                Debug.Log("Jump");
                rigidbody.AddForce(up * JumpStrength, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Flap");
                rigidbody.AddForce(up * FlapStrength, ForceMode.Impulse);
            }
        }

        /* Camera */
        var x = Input.GetAxis("RStick X");
        if (Mathf.Abs(x) < 0.02f)
            x = CrossPlatformInputManager.GetAxis("Mouse X") * 0.7f;
        transform.Rotate(Vector3.up, x * TurnSpeed, Space.Self);

        if (OrientToGround)
        {
            Vector3 fwd = Vector3.ProjectOnPlane(transform.forward, transform.position);
            transform.rotation = Quaternion.LookRotation(fwd, transform.position.normalized);
        }

        // Move the controller
        transform.Translate(moveDirection, Space.Self);
    }

    private Rigidbody CanJump
    {
        get
        {
            return rigidbody;
        }
    }
}