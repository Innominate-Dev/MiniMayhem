using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]

    public List<GameObject> playerList;

    [Header("Game Settings")]
    
    public List<GameObject> spectator;
    public List<GameObject> minigameplayer;

    public List<int> spectator_ID;

    public int m_playerID;
    //this is ID is for the person playing the minigame

    [Header("Round Settings")]

    private float roundtimer;
    public TextMeshProUGUI timerText;

    DiceController diceController;

    public GameState gameState;

    public enum GameState
    {
        Menu,
        CharacterSelection,
        PlayingBoard,
        PlayingMinigame,
        EndScene
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null)
        {
            Debug.Log("Making Singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    private void Start()
    {
        roundtimer = 60.0f;
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        diceController.players = playerList;
    }

    private void Update()
    {

    }

    public void Player_MinigameHandler(GameObject playerObj)
    {
        if (playerObj.name == "Player0") { m_playerID = 0; };
        if (playerObj.name == "Player1") { m_playerID = 1; };
        if (playerObj.name == "Player2") { m_playerID = 2; };
        if (playerObj.name == "Player3") { m_playerID = 3; };



        // Gets the person for who is playing the Minigame and adds them to the list.

        minigameplayer = new List<GameObject>();
        minigameplayer.Add(playerObj);

        // generates a new list for all the players that are spectators.

        spectator = new List<GameObject>();

        for (int i = 0; i < playerList.Count; i++)
        {
            if(playerList[i].gameObject.name != playerObj.name)
            {
                spectator.Add(playerList[i].gameObject);
                Debug.Log("Spectators being added");
            }
        }
    }

    public void PlayerStatusHandler(bool playerDidWin)
    {
        if(playerDidWin)
        {
            // Don't load punishment UI
        }
        if(playerDidWin == false)
        {
            // Load Punishment wheel
        }
    }

    public void updatePlayerList()
    {
        // reloads players into the list
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        diceController.players = playerList;
    }

    void GameStatusHandler()
    {
        //This Manages what ENUM status the game is currently in.
    }

}
