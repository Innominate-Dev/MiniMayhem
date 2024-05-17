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
    SaveDataJSON playerData;

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

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        roundtimer = 60.0f;
        playerData = GameObject.Find("GameManager").GetComponent<SaveDataJSON>();
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        diceController.players = playerList;
    }

    private void Update()
    {
        UpdatePlayerList();
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

    public void clearLists()
    {
        // reloads players into the list
        playerList.Clear();
        minigameplayer.Clear();
        spectator.Clear();

        UpdatePlayerList();
    }

    void UpdatePlayerList()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (playerList.Count == 0 && sceneName == "Game" || sceneName == "Board")
        {
            Debug.Log("Adding players");
            diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
            foreach (GameObject player in diceController.players)
            {
                playerList.Add(player);
            }
        }
    }

    public void GameStatusHandler(string sceneName)
    {
        if (sceneName == "Game" || sceneName == "Board")
        {
            clearLists();

            // loading data

            StartCoroutine(loadingData());
        }
    }

    IEnumerator loadingData()
    {

        yield return new WaitForSeconds(0.5f);

        UpdatePlayerList();

        Debug.Log("Loading player Data");
        playerData = GameObject.Find("GameManager").GetComponent<SaveDataJSON>();
        playerData.LoadPlayerData();
    }

}
