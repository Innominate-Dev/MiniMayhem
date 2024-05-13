using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CountTheEggs : MonoBehaviour
{
    [Header("Game References")]

    [SerializeField]
    private TextMeshProUGUI guessingNumText;
    [SerializeField]
    private Image hand;

    public TextMeshProUGUI timerText;

    [Header("Variables")]

    public List<Transform> eggSpawns;

    [SerializeField]
    private GameObject eggParent;

    [SerializeField]
    private GameObject eggModel;

    [SerializeField]
    private int amountofeggs;

    [SerializeField]
    private int guessamount;

    private float roundTimer;
    private bool cooldown;
    private float inputDelay;


    [Header("Player Input")]

    [SerializeField] public InputActionProperty a_button; // A button
    [SerializeField] public InputActionProperty b_button; // B button
    public bool a_been_pushed;
    public bool b_been_pushed;

    [Header("Sound Effects")]

    private GameObject soundManager;
    [SerializeField]
    private AudioSource numbersfx;
    [SerializeField]
    private AudioSource deniedsfx; 

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetUpMap();
        roundTimer = 60f;
    }

    private void Update()
    {
        float isPressing_a = a_button.action.ReadValue<float>();
        float isPressing_b = b_button.action.ReadValue<float>();

        // Pressing A

        if (isPressing_a > 0.5f && !a_been_pushed)
        {
            a_been_pushed = true;
            //RollingDice();
        }
        if (isPressing_a < 0.5f)
        {
            a_been_pushed = false;
        }

        //Pressing B

        if (isPressing_b > 0.5f && !b_been_pushed)
        {
            b_been_pushed = true;
            //RollingDice();
        }
        if (isPressing_b < 0.5f)
        {
            b_been_pushed = false;
        }

        // cooldown 

        if (cooldown == true)
        {
            inputDelay -= Time.deltaTime;
            if (inputDelay < 0)
            {
                cooldown = false;
                inputDelay = 0.5f;
            }
        }

        MinigameState();
    }

    void SetUpMap()
    {
        amountofeggs = UnityEngine.Random.Range(12, 25);

        for(int i = 0; i < amountofeggs; i++)
        {
            Instantiate(eggModel, eggSpawns[i].position, eggSpawns[i].rotation, eggParent.gameObject.transform);
        }
    }

    void MinigameState()
    {
        // ROUND TIMER //

        roundTimer -= Time.deltaTime;
        roundTimer = Mathf.Round(roundTimer * 100f) / 100f;
        timerText.text = roundTimer.ToString() + "s";
        if (roundTimer < 0)
        {
            if (guessamount == amountofeggs)
            {
                bool playerStatus = true;
                gameManager.PlayerStatusHandler(playerStatus);
            }
            else
            {
                bool playerStatus = false;
                gameManager.PlayerStatusHandler(playerStatus);
            }
        }
    }

    public void IncreaseGuessNum(int pi, bool isPressed)
    {

        if (pi == gameManager.m_playerID && isPressed == true && cooldown == false)
        {
            cooldown = true;
            guessamount++;
            guessingNumText.text = guessamount.ToString();
        }
    }

    public void DecreaseGuessNum(int pi, bool isPressed)
    {

        if (pi == gameManager.m_playerID && isPressed == true && guessamount != 0 && cooldown == false)
        {
            cooldown = true;
            guessamount--;
            guessingNumText.text = guessamount.ToString();
        }
    }

    public void SabotagePlayer(int pi, bool isPressed)
    {
        if (pi != gameManager.m_playerID && isPressed == true)
        {
            Debug.Log("Sabotaging");
        }
    }

}
