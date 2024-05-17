using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveDataJSON : MonoBehaviour
{
    private List<GameObject> players;
    private PlayerData savedPlayerData;
    private bool runOnce;
    private GameManager gameManager;

    [System.Serializable]
    public class PlayerData
    {
        public string Name;
        public int PlayerID;
        public Vector3 Position;
        public int PlayerPOS;
    }

    [System.Serializable]
    public class PlayerDataList
    {
        public List<PlayerData> playerData;

        public PlayerDataList()
        {
            playerData = new List<PlayerData>();
        }
    }

    public PlayerDataList playerDataList = new PlayerDataList();

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void AddPlayerToDataList(PlayerDataList playerDataList, GameObject currentPlayer)
    {
        if (currentPlayer == null)
        {
            Debug.LogError("currentPlayer is null.");
            return;
        }

        PlayerDataHandler currentPlayerData = currentPlayer.GetComponent<PlayerDataHandler>();

        if (currentPlayerData == null)
        {
            Debug.LogError("PlayerData script is missing from the currentPlayer object.");
            return;
        }

        PlayerData playerData = new PlayerData();
        playerData.PlayerID = currentPlayerData.playerId;
        playerData.Name = currentPlayerData.playername;
        playerData.PlayerPOS = currentPlayerData.playerPOS;
        playerData.Position = currentPlayer.transform.position;
        playerDataList.playerData.Add(playerData);
    }

    private void UpdatePlayerFromDataList(PlayerDataList playerDataList, GameObject currentPlayer)
    {
        PlayerDataHandler currentPlayerData = currentPlayer.GetComponent<PlayerDataHandler>();

        PlayerData playerData = new PlayerData();

        playerData.PlayerID = currentPlayerData.playerId;
        playerData.Name = currentPlayerData.playername;
        playerData.PlayerPOS = currentPlayerData.playerPOS;
        playerData.Position = currentPlayer.transform.position;
        playerDataList.playerData.Add(playerData);
        playerData = savedPlayerData;
    }

    private void LoadingPlayerDataFromDataList(PlayerDataList playerDataList, GameObject currentPlayer)
    {
        PlayerDataHandler currentPlayerData = currentPlayer.GetComponent<PlayerDataHandler>();

    }

    private void Update()
    {
        if(runOnce == false)
        {
            PlayerDataList playerDataList = new PlayerDataList();
            if (gameManager.playerList.Count > 0)
            {
                Debug.Log("Player List is not empty.");
                foreach (GameObject currentPlayer in gameManager.playerList)
                {
                    AddPlayerToDataList(playerDataList, currentPlayer);
                }
                runOnce = true;
                OutputJSON(playerDataList);
            }
            else
            {
                Debug.LogError("Player List is empty.");
            }
        }
    }

    public void OutputJSON(PlayerDataList playerDataList)
    {
        // makes the file and saves the text file

        Debug.Log(Application.dataPath);

        string strOutput2 = JsonUtility.ToJson(playerDataList);
         
        File.WriteAllText(Application.dataPath + "/Scripts/DataManagement" + "/PlayerDataList.txt", strOutput2);
    }

    public void SavePlayerData()
    {
        Debug.Log("Saving...");
        playerDataList.playerData.Clear();
        foreach (GameObject currentPlayer in gameManager.playerList)
        {
            UpdatePlayerFromDataList(playerDataList, currentPlayer);
        }
        OutputJSON(playerDataList);
    }

    public void LoadPlayerData()
    {
        Debug.Log("Loading Data");
        foreach (GameObject currentPlayer in gameManager.playerList)
        {
            PlayerDataHandler currentPlayerData = currentPlayer.GetComponent<PlayerDataHandler>();
            PlayerData playerData = playerDataList.playerData
               .FirstOrDefault(pd => pd.Name == currentPlayerData.playername);
            if (playerData != null)
            {
                currentPlayerData.playerPOS = playerData.PlayerPOS;
                currentPlayerData.SetPlayerPOS(playerData.PlayerPOS);
                currentPlayer.transform.position = playerData.Position;

                // Load other data as needed
            }
        }
    }
}