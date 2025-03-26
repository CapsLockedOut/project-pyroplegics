using UnityEngine;
using UnityEngine.InputSystem;  // Required for the new Input System

public class PlayerMovement : MonoBehaviour
{
    // Camera Rotation
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;
    
    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;   // Multiplies gravity when falling down
    public float ascendMultiplier = 2f;   // Multiplies gravity when rising
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main ? Camera.main.transform : null;
        
        if (cameraTransform == null)
        {
            Debug.LogError("No main camera found! Please assign a camera with the tag 'MainCamera'.");
        }

        // Set the raycast to be slightly beneath the player's feet
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Hides and locks the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Reset movement inputs
        moveHorizontal = 0f;
        moveForward = 0f;

        // Read keyboard input using the new Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) moveHorizontal -= 1f;
            if (Keyboard.current.dKey.isPressed) moveHorizontal += 1f;
            if (Keyboard.current.wKey.isPressed) moveForward += 1f;
            if (Keyboard.current.sKey.isPressed) moveForward -= 1f;
        }

        RotateCamera();

        // Jump input: space key triggers jump
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }

        // Ground check with a slight delay to prevent false negatives mid-jump
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
    }

    void MovePlayer()
    {
        // Combine movement direction vectors and normalize
        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        Vector3 targetVelocity = movement * MoveSpeed;

        // Apply horizontal movement to the Rigidbody's velocity
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.linearVelocity = velocity;

        // Stop sliding when no movement input is provided and on the ground
        if (isGrounded && Mathf.Approximately(moveHorizontal, 0f) && Mathf.Approximately(moveForward, 0f))
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void RotateCamera()
    {
        // Check if a mouse device is available
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            float horizontalRotation = mouseDelta.x * mouseSensitivity;
            transform.Rotate(0, horizontalRotation, 0);

            verticalRotation -= mouseDelta.y * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            if (cameraTransform != null)
            {
                cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
            }
        }
    }

    void Jump()
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        // Set upward velocity for the jump
        Vector3 velocity = rb.linearVelocity;
        velocity.y = jumpForce;
        rb.linearVelocity = velocity;
    }

    void ApplyJumpPhysics()
    {
        // If falling, increase gravity effect; if rising, apply a different multiplier
        if (rb.linearVelocity.y < 0) 
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }
}
