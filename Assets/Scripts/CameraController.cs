using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector2 bowInput;

    [SerializeField]
    private float cameraSpeed = 10f;
    [SerializeField]
    private float lookSpeed = 100f;
    [SerializeField]
    private float bowSpeed = 10f;

    public Transform cameraTransform;
    public Transform bowTransform;

    public PlayerInput moveAction;
    public PlayerInput lookAction;
    public PlayerInput bowAction;

    private void Awake()
    {        
        bowTransform = GameObject.FindWithTag("Bow").transform;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnBow(InputAction.CallbackContext context)
    {
        bowInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {


        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        cameraTransform.position += moveDir * cameraSpeed * Time.deltaTime;

        Vector2 lookDir = lookInput * lookSpeed * Time.deltaTime;
        cameraTransform.Rotate(Vector3.up, lookDir.x);
        bowTransform.Rotate(-Vector3.right, lookDir.y);

        bowTransform.position += bowTransform.forward * bowInput.y * bowSpeed * Time.deltaTime;
    }
}