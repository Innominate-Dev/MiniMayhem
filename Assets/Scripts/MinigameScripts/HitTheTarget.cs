using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitTheTarget : MonoBehaviour
{
    [Header("Cameras")]
    public Camera mainCamera;
    public Camera aimInCamera;

    [Header("Players")]

    private int player_index;
    [Tooltip("This is index is for the player who is playing the minigame since they landed on the tile")]


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimDown(int pi, bool isPressed)
    {
        mainCamera.gameObject.SetActive(false);
        aimInCamera.gameObject.SetActive(true);
    }

    public void AimDown(InputAction.CallbackContext context)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        if (context.performed)
        {
            mainCamera.gameObject.SetActive(false);
            aimInCamera.gameObject.SetActive(true);
        }


    }


}
