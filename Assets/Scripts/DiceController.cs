using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DiceController : MonoBehaviour
{
    [Header("Dice Settings")]

    [SerializeField] public GameObject dice;
    //[SerializeField] public GameObject dice2;
    [SerializeField] public Rigidbody diceRB;
    [SerializeField] private float rollForce;
    //[SerializeField] public Rigidbody diceRB2;
    [SerializeField] public List<GameObject> diceNum;
    [SerializeField] public GameObject backWall;
    [SerializeField] public int diceRolled;
    [SerializeField] private bool hasBeenRolled;

    [Header("Positions")]

    [SerializeField] private int currentPos = 0;

    [Header("Player Settings")]

    [SerializeField] public GameObject player1;

    [Header("Camera")]

    [SerializeField] public Camera rollingCam;
    [SerializeField] public Camera mainCam;

    [Header("Input System")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Waypoints")]
    public List<GameObject> waypointList;

    [Header("Script References")]

    [SerializeField] NumberRolled numRolled;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        numRolled = FindAnyObjectByType<NumberRolled>();
    }

    // Update is called once per frame
    void Update()
    {
        // DICE ROLLING LOGIC //

        if (hasBeenRolled)
        {
            Debug.Log(diceRB.velocity);
            if (diceRB.velocity == Vector3.zero) // sees if the dice is rolling and constantly updates if true to see if it has stopped rolling
            {
                hasBeenRolled = false;

                StartCoroutine(moveToWaypoint());

            }
        }


    }

    public void RollingDice(InputAction.CallbackContext context)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        if (context.performed)
        {
            mainCam.gameObject.SetActive(false);
            rollingCam.gameObject.SetActive(true);

            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            diceRB.velocity = transform.up * rollForce;
            diceRB.AddTorque(dirX, dirY, dirZ);
            //diceRB2.AddForce(transform.up * 350);
            //diceRB2.AddTorque(dirX, dirY, dirZ); //For Dice 2

            hasBeenRolled = true;
        }
    }

    IEnumerator moveToWaypoint()
    {
        diceRolled = numRolled.diceRolled;

        int newPos = (diceRolled + currentPos);

        Vector3 moveToPoint = waypointList[newPos].gameObject.transform.position;

        player1.transform.position = moveToPoint;
        currentPos = currentPos + diceRolled;

        yield return null;
    }
}
