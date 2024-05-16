using System.Collections;
using System.Collections.Generic;
using System.Net;
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
    private List<Image> hands;
    [SerializeField]
    private Transform lefthandFinalPOS;
    [SerializeField]
    private Transform righthandFinalPOS;

    [SerializeField]
    private Transform r_OriginalPOS;
    [SerializeField]
    private Transform l_OriginalPOS;

    private Transform originalPOS;
    public TextMeshProUGUI timerText;
    private Image chosen_Hand;

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

    [SerializeField]
    private float handSpeed = 1f;

    private float smoothTime;
    private float roundTimer;
    private bool cooldown;
    private bool canSabotage;
    private float inputDelay;
    private float sabotageCooldown;

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
    private bool sabotageButtonPressed;

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

        // canSabotage

        if (canSabotage == false)
        {
            sabotageCooldown -= Time.deltaTime;
            if (sabotageCooldown < 0)
            {
                if (chosen_Hand != null)
                {
                    if (chosen_Hand.name == "Left Hand")
                    {
                        StartCoroutine(ReturnToPOS(l_OriginalPOS));
                        Debug.Log("Returning to orignial POS for left");

                    }
                    if (chosen_Hand.name == "Right Hand")
                    {
                        StartCoroutine(ReturnToPOS(r_OriginalPOS));
                        Debug.Log("Returning to orignial POS for right");
                    }
                }
                canSabotage = true;
                sabotageCooldown = 2.5f;
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
        float seconds = Mathf.FloorToInt(roundTimer % 60);
        timerText.text = seconds.ToString() + "s";
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
        if (pi != gameManager.m_playerID && isPressed == true && canSabotage == true && sabotageButtonPressed == false)
        {
            canSabotage = false;
            sabotageButtonPressed = true;
            int range = Random.Range(0, hands.Count);

            chosen_Hand = hands[range];

            if (chosen_Hand.gameObject.name == "Left Hand")
            {
                //handSpeed = Mathf.Clamp(handSpeed + Time.deltaTime * smoothTime, 0f, 1f);
                //chosen_Hand.rectTransform.position = Vector3.Lerp(chosen_Hand.rectTransform.position, lefthandFinalPOS.position, handSpeed);
                originalPOS = chosen_Hand.transform;
                StartCoroutine(LerpObject(lefthandFinalPOS));
            }
            if (chosen_Hand.gameObject.name == "Right Hand")
            {
                //handSpeed = Mathf.Clamp(handSpeed + Time.deltaTime * smoothTime, 0f, 1f);
                //chosen_Hand.rectTransform.position = Vector3.Lerp(chosen_Hand.rectTransform.position, righthandFinalPOS.position, handSpeed);
                originalPOS = chosen_Hand.transform;
                StartCoroutine(LerpObject(righthandFinalPOS));
            }
        }

    }

    IEnumerator LerpObject(Transform endPoint)
    {

        float timeOfTravel = 5; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue = 0;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            chosen_Hand.rectTransform.position = Vector3.Lerp(chosen_Hand.rectTransform.position, endPoint.position, normalizedValue);
            yield return null;
        }
    }

    IEnumerator ReturnToPOS(Transform endPoint)
    {

        float timeOfTravel = 17; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;
        float step;
        

        while (currentTime <= timeOfTravel)
        {
            step = handSpeed * Time.deltaTime;
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            chosen_Hand.rectTransform.position = Vector3.MoveTowards(chosen_Hand.rectTransform.position, endPoint.position, step);
            yield return null;
        }
        sabotageButtonPressed = false;
    }

}
