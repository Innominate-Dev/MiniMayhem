using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int maxPlayers = 2;

    public static PlayerConfigManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Making Singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerCharacter(int index, Material color)
    {
        playerConfigs[index].PlayerMaterial = color;
    }
    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;

        if(playerConfigs.Count == maxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void HandlePlayerJoined(PlayerInput pi)
    {
        Debug.Log("Player Joined " + pi.playerIndex);
        pi.transform.SetParent(transform);
        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex)) 
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; set; }

    public int PlayerIndex { get; set; }
    public bool isReady{ get; set; }
    public Material PlayerMaterial { get; set; }
}