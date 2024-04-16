using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private float m_Timer;
    [SerializeField] private bool isPlayerInTrigger;
    [SerializeField] private string m_MinigameName;

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
        if(other.CompareTag("Player") && isPlayerInTrigger == true)
        {
            if (m_Timer > 0)
            {
                gameObject.name = m_MinigameName;
                SceneManager.LoadScene(m_MinigameName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
