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
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        
    }

    void Update()
    {
        /* Movement */
        moveDirection = (Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection.normalized * MoveSpeed * Time.deltaTime;

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        // Move the controller
        transform.Translate(moveDirection, Space.Self);

        /* Camera */
        var x = CrossPlatformInputManager.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, x * TurnSpeed, Space.Self);
    }
}