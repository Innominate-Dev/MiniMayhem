using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // The speed at which the camera moves
    public float moveSpeed = 5.0f;
    // The sensitivity of the camera's look controls
    public float lookSensitivity = 100.0f;
    // The maximum vertical angle of the camera
    public float maxVerticalAngle = 85.0f;

    // The current input for the camera's movement
    private Vector2 moveInput;
    // The current input for the camera's look controls
    private Vector2 lookInput;
    // The current vertical angle of the camera
    private float verticalAngle;

    // The player's body (used for rotating the camera around)
    private Transform playerBody;

    void Start()
    {
        // Get the player's body
        playerBody = transform.parent.GetComponentInChildren<SkinnedMeshRenderer>().transform;

        // Set the initial vertical angle of the camera
        verticalAngle = transform.localEulerAngles.x;
    }

    void Update()
    {
        // Calculate the camera's movement
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime;
        transform.position += moveDir;

        // Calculate the camera's look controls
        float lookX = lookInput.x * lookSensitivity * Time.deltaTime;
        float lookY = lookInput.y * lookSensitivity * Time.deltaTime;

        // Clamp the vertical angle of the camera
        verticalAngle = Mathf.Clamp(verticalAngle - lookY, -maxVerticalAngle, maxVerticalAngle);

        // Rotate the camera around the player's body
        transform.RotateAround(playerBody.position, Vector3.up, lookX);

        // Set the local rotation of the camera
        transform.localEulerAngles = new Vector3(verticalAngle, 0, 0);
    }

    // The function that is called when the Move Forward/Backward stick is moved
    public void OnMoveForward(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // The function that is called when the Move Left/Right stick is moved
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // The function that is called when the Look Up/Down stick is moved
    public void OnLookUp(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    // The function that is called when the Look Left/Right stick is moved
    public void OnLookRight(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}