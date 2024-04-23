using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform orientation;
    private void Update()
    {
        ///////////////////////// ROTATATION ORIENTATION ///////////////////////////////////
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
    }
}