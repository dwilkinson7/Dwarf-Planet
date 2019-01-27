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
    public int _axeStrengthDebugModifier;
    public bool OrientToGround;
    private Vector3 moveDirection = Vector3.zero;

    [Header("Components")]
    public Rigidbody rigidbody;
    public Animator dwarfAnimator;
    public ParticleSystem DustMaker;
    public Camera mainCamera;

    private bool _isSwinging;

    public int AxePower
    {
        get
        {
            return 1 + _axeStrengthDebugModifier;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    bool isWalking;
    public AudioSource foodstepAudio;
    public AudioSource swingaxeAudio;
    public AudioSource jumpAudio;
    public AudioSource smashimpactAudio;
    void Update()
    {
        /* Movement */
        moveDirection = (Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection.normalized * MoveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && CanJump)
        {
            jumpAudio.Play();
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

        var y = Input.GetAxis("RStick Y");
        if (Mathf.Abs(y) < 0.02f)
            y = -2*CrossPlatformInputManager.GetAxis("Mouse Y") * 0.7f;
        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, y);

        if (Input.GetButtonDown("Fire1") && !_isSwinging)
        {
            /*
            Swing();
            */
            _isSwinging = true;
            dwarfAnimator.SetBool("Attacking", true);
            Invoke("Swing", 0.9f);
            swingaxeAudio.PlayDelayed(0.7f);
            Invoke("EndSwing", 1f);
        }

        if (!_isSwinging && moveDirection.magnitude > 0.01f)
        {
            if (isWalking == false)
            {
                foodstepAudio.Play();
                dwarfAnimator.SetBool("Moving", true);
                isWalking = true;
            }
            // Move the controller
            transform.Translate(moveDirection, Space.Self);
        }
        else
        {
            if (isWalking)
            {
                dwarfAnimator.SetBool("Moving", false);
                foodstepAudio.Stop();
                isWalking = false;
            }
        }

        if (OrientToGround)
        {
            Vector3 fwd = Vector3.ProjectOnPlane(transform.forward, transform.position);
            transform.rotation = Quaternion.LookRotation(fwd, transform.position.normalized);
        }
    }

    private Rigidbody CanJump
    {
        get
        {
            return rigidbody;
        }
    }

    public void Swing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.up, transform.forward, out hit, 2f, ~LayerMask.GetMask("Player"), QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(transform.position + transform.up, transform.position + transform.up + transform.forward * 2, Color.green, 2f);
            var smashable = hit.collider.GetComponent<Smashable>();
            if (smashable)
            {
                smashimpactAudio.Play();
                if (DustMaker)
                {
                    DustMaker.transform.position = hit.point;
                    DustMaker.Play();
                }
                else
                {
                    Debug.LogWarning("No DustMaker linked");
                }

                var rewardTemplate = smashable.Smash(AxePower);
                if (rewardTemplate)
                {
                    var pos = hit.point + (hit.point.normalized * 2);
                    var rot = transform.rotation;
                    var rewardActual = Instantiate(rewardTemplate, pos, rot);
                }
            }
        }
    }

    public void EndSwing()
    {
        _isSwinging = false;
        dwarfAnimator.SetBool("Attacking", false);
    }
}