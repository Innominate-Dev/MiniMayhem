using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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

    [SerializeField] private int plrRollingIndex = 1;

    [Header("Player Settings")]

    [SerializeField] 
    public List<GameObject> players;
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab;

    public GameObject currentPlayer;

    public Vector3 moveToPoint;
     
    public bool isMoving;

    public PlayerTurn playerTurn;

    public enum PlayerTurn
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    [Header("Camera")]

    [SerializeField] public Camera rollingCam;
    [SerializeField] public Camera mainCam;

    [Header("User Interface")]

    public TextMeshProUGUI rollingText;

    [Header("Input System")]

    [SerializeField] public InputActionProperty rollingButton;
    public bool has_been_pushed;

    [Header("Waypoints")]
    public List<GameObject> waypointList;

    [Header("Script References")]

    [SerializeField] NumberRolled numRolled;
    [SerializeField] Mover2 mover;

    private int index;
    private float speed;

    private void Awake()
    {
        numRolled = FindAnyObjectByType<NumberRolled>();
    }

    private void Start()
    {
        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int p = 0; p < playerConfigs.Length; p++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[p].position, playerSpawns[p].rotation, gameObject.transform);
            player.name = "Player" + p;
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[p]);
            players.Add(player);
        }

        mover = FindAnyObjectByType<Mover2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rollingCam != null)
        {
            numRolled = FindAnyObjectByType<NumberRolled>();
        }

        // DICE ROLLING LOGIC //

        float isPressing = rollingButton.action.ReadValue<float>();

        if (isPressing > 0.5f && !has_been_pushed)
        {
            has_been_pushed = true;
            //RollingDice();
        }
        if (isPressing < 0.5f)
        {
            has_been_pushed = false;
        }


        if (hasBeenRolled)
        {
            
            if (diceRB.velocity == Vector3.zero) // sees if the dice is rolling and constantly updates if true to see if it has stopped rolling
            {
                hasBeenRolled = false;

                StartCoroutine(MoveToWaypoint());
            }
        }

        if (isMoving)
        {
            //currentPlayer.gameObject.transform.position = Vector3.Lerp(currentPlayer.gameObject.transform.position, moveToPoint, 1f *Time.deltaTime);
            mainCam.gameObject.SetActive(true);

            mover.isMoving = true;

        }


    }

    public void RollingDice(int pi, bool isPressed)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        pi++;

        if(pi == plrRollingIndex && isPressed == true)
        {
            isMoving = false;
            mainCam.gameObject.SetActive(false);
            rollingCam.gameObject.SetActive(true);

            float dirX = UnityEngine.Random.Range(0, 500);
            float dirY = UnityEngine.Random.Range(0, 500);
            float dirZ = UnityEngine.Random.Range(0, 500);

            diceRB.velocity = transform.up * rollForce;
            diceRB.AddTorque(dirX, dirY, dirZ);
            //diceRB2.AddForce(transform.up * 350);
            //diceRB2.AddTorque(dirX, dirY, dirZ); //For Dice 2

            hasBeenRolled = true;
        }
    }

    public void WhoIsRollingDice(int index)
    {
        if (index == 1) { playerTurn = PlayerTurn.Player1; }
        if (index == 2) { playerTurn = PlayerTurn.Player2; }
        if (index == 3) { playerTurn = PlayerTurn.Player3; }
        if (index == 4) { playerTurn = PlayerTurn.Player4; }
    }

    public void NextPlayerRolling()
    {
        if (plrRollingIndex < players.Count)
        {
            Debug.Log("PLAYER ROLLING IS!" + plrRollingIndex);
            plrRollingIndex++; // changes the person rolling enum state
            WhoIsRollingDice(plrRollingIndex);
        }
        else
        {
            plrRollingIndex = 1;
            WhoIsRollingDice(plrRollingIndex);
        }

    }

    IEnumerator MoveToWaypoint()
    {
        //GameObject currentPlayer = null;

        if (playerTurn == PlayerTurn.Player1) { currentPlayer = players[0];}
        else if (playerTurn == PlayerTurn.Player2) { currentPlayer = players[1];}
        else if (playerTurn == PlayerTurn.Player3) { currentPlayer = players[2];}
        else if (playerTurn == PlayerTurn.Player4) { currentPlayer = players[3];}

        diceRolled = numRolled.diceRolled;

        mover = currentPlayer.GetComponent<Mover2>();

        mover.playerPOS = (diceRolled + mover.playerPOS);

        moveToPoint = waypointList[mover.playerPOS].gameObject.transform.position;

        Debug.Log("CURRENT PLAYER" + currentPlayer);

        ///////////////// NOTE TO SELF ////////////////
        /// Tested out different ways of moving but I need to move these into an update feature i.e make a function that runs the lines of codes shown down below and 
        /// make a bool that says whether the are moving which we can also enable to the main camera.

        //currentPlayer.gameObject.transform.position = moveToPoint;
        //currentPlayer.gameObject.transform.position = Vector3.Lerp(currentPlayer.transform.position, moveToPoint * Time.deltaTime) ;

        //currentPlayer.gameObject.transform.position = Vector3.Lerp(currentPlayer.gameObject.transform.position, moveToPoint, 1f);
        //currentPlayer.gameObject.transform.Translate(moveToPoint * 15 * Time.deltaTime);
        //player1.MoveTowards() // Add lerping this is for FUTURE reference

        isMoving = true;

        Invoke("NextPlayerRolling", 1);

        yield return null;
    }
}
