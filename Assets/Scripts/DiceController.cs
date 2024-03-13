using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceController : MonoBehaviour
{
    [Header("Dice Settings")]

    [SerializeField] public GameObject dice;
    [SerializeField] public int diceRolled;


    [Header("Input System")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Waypoints")]
    public List<GameObject> waypointList;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RollingDice(InputAction.CallbackContext context)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        if (context.performed)
        {
            diceRolled = Random.Range(0, 6);

            Debug.Log(diceRolled);
        }

 
    }
}
