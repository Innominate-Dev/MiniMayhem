using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanceCard : MonoBehaviour
{
    private GameObject player;
    private float m_Timer;
    private bool isPlayerInTrigger;

    [SerializeField]
    private List<string> chanceCards;
    [SerializeField]
    private string card_picked;

    Mover2 mover;
    private void Start()
    {
        m_Timer = 5f;
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
            if (mover.isMoving == false)
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
            mover.playerPOS = (3 - mover.playerPOS);

            Debug.Log("Going back 3");
        }
        else if(card_picked.Contains("back 5"))
        {
            mover.playerPOS = (5 - mover.playerPOS);

            Debug.Log("Going back 5");
        }        
        else if(card_picked.Contains("back 4"))
        {
            mover.playerPOS = (4 - mover.playerPOS);

            Debug.Log("Going back 4");
        }
        else if(card_picked.Contains("forward 2"))
        {
            mover.playerPOS = (2 + mover.playerPOS);

            Debug.Log("Going forward 2");
        }
        else if(card_picked.Contains("Skip a turn"))
        {
            DiceController diceController;
        }
        else
        {
            Debug.Log("Your safe g");
        }
    }
}
