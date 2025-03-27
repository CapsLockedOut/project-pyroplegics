using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform cameraPosition;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = cameraPosition.position;

        // read mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // move current orientation by 'mouse input amount'
        yRotation += mouseX;
        xRotation -= mouseY;

        // prevent player looking too far upwards/downwards
        xRotation = Mathf.Clamp(xRotation, -90f, 100f);

        // apply rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
