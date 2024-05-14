using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private float m_Timer;
    [SerializeField] private bool isPlayerInTrigger;
    [SerializeField] private string m_MinigameName;
    [SerializeField] private GameManager gameManager;
    
    public int m_MinigameID;

    [Header("Script References")]

    SceneLoader sceneLoader;
    Mover2 playerMover;

    private void Start()
    {
        m_Timer = 5f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sceneLoader = GameObject.Find("TransitionManager").GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (isPlayerInTrigger == true)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer < 0)
            {
                m_Timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && isPlayerInTrigger == true)
        {
            playerMover = other.gameObject.GetComponent<Mover2>();
            if (m_Timer > 0 && m_MinigameID == playerMover.playerPOS)
            {
                // if the player is in the trigger and their POS matches the minigame ID it will run the following code.
                GameObject minigame_Player = other.gameObject;
                gameManager.Player_MinigameHandler(minigame_Player);
                gameObject.name = m_MinigameName;
                sceneLoader.LoadScene(m_MinigameName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            m_Timer = 5;
        }
    }
}
