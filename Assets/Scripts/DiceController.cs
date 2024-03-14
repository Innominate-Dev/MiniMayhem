using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceController : MonoBehaviour
{
    [Header("Dice Settings")]

    [SerializeField] public GameObject dice;
    //[SerializeField] public GameObject dice2;
    [SerializeField] public Rigidbody diceRB;
    //[SerializeField] public Rigidbody diceRB2;
    [SerializeField] public List<GameObject> diceNum;
    [SerializeField] public GameObject backWall;
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
            Debug.Log(diceRolled);

            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);


            diceRB.AddForce(transform.up * 350);
            diceRB.AddTorque(dirX, dirY, dirZ);
            //diceRB2.AddForce(transform.up * 350);
            //diceRB2.AddTorque(dirX, dirY, dirZ); //For Dice 2

            

        }
    }
}
