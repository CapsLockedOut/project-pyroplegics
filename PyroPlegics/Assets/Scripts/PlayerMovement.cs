using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float drag;

    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public LayerMask whatIsGround;
    public float playerHeight;
    bool onGround;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // vector representing movement direction
        moveDirection = orientation.forward * verticalInput +
                        orientation.right * horizontalInput;

        // midair movement
        if(!onGround)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void Update()
    {
        // check if on ground via raycast from camera pos to ground
        onGround = Physics.Raycast(transform.position, Vector3.down,
                                   playerHeight * 0.5f + 0.2f, whatIsGround);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // jump
        if(Input.GetKey(jumpKey) && readyToJump && onGround)
        {
            readyToJump = false;

            // reset y velocity, then jump
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // allows for continous jumping
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // handle friction; to be done by individual platforms in the future?
        if(!onGround)
            rb.linearDamping = drag;
        else
            rb.linearDamping = drag * 2;
    }

    private void ResetJump() {
        readyToJump = true;
    }
}
