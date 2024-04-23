using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]

    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab;

    [Header("Game Settings")]
    
    public List<GameObject> spectator;
    public List<GameObject> minigameplayer;

    [Header("Round Settings")]

    private float roundtimer;
    public TextMeshProUGUI timerText;

    public GameState gameState;

    public enum GameState
    {
        Menu,
        CharacterSelection,
        PlayingBoard,
        PlayingMinigame,
        EndScene
    }

    private void Start()
    {
        roundtimer = 60.0f;
        var playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

    private void Update()
    {
        if(gameState == GameState.PlayingMinigame)
        {
            roundtimer -= Time.deltaTime;
            roundtimer = Mathf.Round(roundtimer * 100f) / 100f;
            timerText.text = roundtimer.ToString() + "s";

            if (roundtimer <= 0f)
            {
                gameState = GameState.PlayingBoard;
                SceneManager.LoadScene("Game");
            }
        }
    }

}
