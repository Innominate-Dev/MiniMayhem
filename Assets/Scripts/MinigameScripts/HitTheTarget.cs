using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitTheTarget : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject aimInCamera;

    [Header("Player data")]

    private int player_index;
    [Tooltip("This is index is for the player who is playing the minigame since they landed on the tile")]

    #region GameReferences
    [Header("Game References")]

    public Transform firepoint;
    public GameObject arrowPrefab;
    public Rigidbody arrowRB;

    private float arrowSpeed = 100.0f;


    private bool canUseBow;
    private bool drawingBow;

    #endregion

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
            mainCamera.SetActive(false);
            aimInCamera.SetActive(true);
        }
        else if (context.canceled)
        {
            mainCamera.SetActive(true);
            aimInCamera.SetActive(false);
        }
    }

    public void PowerShot(InputAction.CallbackContext context)
    {
        canUseBow = true;
        if(context.performed)
        {
            if(canUseBow)
            {
                GameObject clonedarrow = Instantiate(arrowPrefab, firepoint);
                arrowRB.isKinematic = false;
                arrowRB.AddForce(clonedarrow.transform.forward ,ForceMode.Impulse);
            }
        }
    }

    public void OnReloadArrow()
    {

    }

}
