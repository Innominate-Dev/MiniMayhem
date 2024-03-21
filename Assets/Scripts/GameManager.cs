using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]

    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab;

    [Header("Game Settings")]
    
    [SerializeField]
    private float rollingDiceTimer;

    [Header("Ayaans Car")]
    private float Timer; 


    public enum gameState
    {
        Menu,
        CharacterSelection,
        PlayingBoard,
        PlayingMinigame,
        EndScene
    }

    private void Start()
    {
        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

}
