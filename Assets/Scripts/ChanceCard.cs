using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanceCard : MonoBehaviour
{
    private GameObject player;
    public float m_Timer;
    public bool isPlayerInTrigger;
    public bool chanceCardTaken;

    [SerializeField]
    private List<string> chanceCards;
    [SerializeField]
    private string card_picked;

    DiceController diceController;
    Mover2 mover;
    private void Start()
    {
        m_Timer = 5f;
        diceController = FindAnyObjectByType<DiceController>();
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
        if (other.CompareTag("Player") && isPlayerInTrigger == true)
        {
            mover = other.gameObject.GetComponent<Mover2>();
            if (mover.isMoving == false && chanceCardTaken == false)
            {
                PickingUpCard();
                WhatCardIsIt(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chanceCardTaken = false;
            isPlayerInTrigger = false;
            m_Timer = 5;
        }
    }

    void PickingUpCard()
    {
        int range = UnityEngine.Random.Range(0, chanceCards.Count);

        card_picked = chanceCards[range];
    }

    private void WhatCardIsIt(GameObject player)
    {
        if (card_picked.Contains("back 3"))
        {
            mover.playerPOS = (mover.playerPOS - 3);

            Debug.Log("Going back 3");
            card_picked = null;
        }
        else if(card_picked.Contains("back 5"))
        {
            mover.playerPOS = (mover.playerPOS - 5);

            Debug.Log("Going back 5");
            
            card_picked = null;
        }        
        else if(card_picked.Contains("back 4"))
        {
            mover.playerPOS = (mover.playerPOS - 4);

            Debug.Log("Going back 4");
            
            card_picked = null;
        }
        else if(card_picked.Contains("forward 2"))
        {
            mover.playerPOS = (2 + mover.playerPOS);

            Debug.Log("Going forward 2");
            
            card_picked = null;
        }
        else if(card_picked.Contains("Skip a turn"))
        {
            diceController.SkipPlayerTurn();
            
            card_picked = null;
        }
        else
        {
            Debug.Log("Your safe g");
            
            card_picked = null;
        }

        chanceCardTaken = true;
    }
}
