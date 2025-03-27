using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float friction;

    public float jumpForce;
    public float jumpCooldown;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
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
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f,
                        ForceMode.Force);
    }

    void Update()
    {
        // read movement input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // jump
        if(Input.GetKey(jumpKey) && readyToJump && onGround)
        {
            readyToJump = false;

            // reset y velocity, then jump
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f,
                                            rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // allows for continous jumping
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // handle friction; to be done by individual platforms in the future?
        if(onGround)
            rb.linearDamping = friction;
        else
            rb.linearDamping = 0;
    }

    private void ResetJump() {
        readyToJump = true;
    }

    // temp solution to onGround detection
    // there's weird edgecase (dunno when it happens) where the collision enter
    // is undetected
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
            onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
            onGround = false;
    }
}
