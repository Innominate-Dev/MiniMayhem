using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HitTheTarget : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject aimInCamera;

    [Header("Player Input")]
    [SerializeField] private InputActionProperty lt_AimIn; // left trigger
    [SerializeField] private InputActionProperty rt_Shooting; // right trigger
    [SerializeField] private InputActionProperty a_button; // a button
    public bool lt_been_pushed;
    public bool rt_been_pushed;
    public bool a_been_pushed;

    [Header("Player data")]

    private int player_index;
    [Tooltip("This is index is for the player who is playing the minigame since they landed on the tile")]

    #region GameReferences
    [Header("Game References")]

    public Transform firepoint;
    public GameObject arrowPrefab;
    public Rigidbody arrowRB;
    public TextMeshProUGUI timerText;
    private TextMeshProUGUI targetsHitText;
    private float arrowSpeed = 25.0f;

    private int amountTargetHit = 0;

    private bool canUseBow;
    private bool drawingBow;
    private float m_timer;
    private float roundTimer;

    public Transform selected_Target;
    public List<Transform> target_Transforms;
    private bool canSabotage;
    private float targetCooldown;

    GameManager GameManager;
    SceneLoader sceneLoader;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.Find("GameManager").GetComponent<SceneLoader>();
        roundTimer = 60.0f;
        targetsHitText = GameObject.Find("TargetsHitText").GetComponent<TextMeshProUGUI>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Transform[] target_Transforms = GameObject.Find("Target").GetComponents<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Getting Target Groups // 

        if (target_Transforms.Count == 0)
        {
            Transform[] target_Transforms = GameObject.Find("Target").GetComponents<Transform>();
            
        }

        // ROUND TIMER //

        roundTimer -= Time.deltaTime;
        roundTimer = Mathf.Round(roundTimer * 100f) / 100f;
        timerText.text = roundTimer.ToString() + "s";
        if (roundTimer < 0)
        {
            bool playerStatus = false;
            GameManager.PlayerStatusHandler(playerStatus);
        }

        // Can the player use the bow?

        if (canUseBow == false)
        {
            m_timer -= Time.deltaTime;
            if (m_timer < 0)
            {
                canUseBow = true;
                m_timer = 2.5f;
            }
        }

        // Can the spectator sabotage?

        if (canSabotage == false)
        {


            targetCooldown -= Time.deltaTime;
            if (targetCooldown < 0)
            {
                if(selected_Target != null)
                {
                    selected_Target.Rotate(selected_Target.rotation.x, selected_Target.rotation.y, 90);
                }
                canSabotage = true;
                targetCooldown = 2.5f;
            }
        }

        // Load scene if target amount equals 6 //

        if (amountTargetHit == 6)
        {
            Invoke("LoadScene", 1);
        }

        float isPressing_lt = lt_AimIn.action.ReadValue<float>();
        float isPressing_rt = rt_Shooting.action.ReadValue<float>();
        float isPressing_a = a_button.action.ReadValue<float>();

        // pressing rt //

        if (isPressing_rt > 0.5f && !rt_been_pushed)
        {
            rt_been_pushed = true;
            //RollingDice();
        }
        if (isPressing_rt < 0.5f)
        {
            rt_been_pushed = false;
        }

        //pressing lt 

        if (isPressing_lt > 0.5f && !lt_been_pushed)
        {
            lt_been_pushed = true;
            //RollingDice();
        }
        if (isPressing_lt < 0.5f)
        {
            lt_been_pushed = false;
        }

        if (isPressing_a > 0.5f && !rt_been_pushed)
        {
            a_been_pushed = true;
            //RollingDice();
        }
        if (isPressing_a < 0.5f)
        {
            a_been_pushed = false;
        }

    }

    public void AimDown(int pi, bool isPressed)
    {
        if (pi == GameManager.m_playerID && isPressed == true)
        {
            mainCamera.SetActive(false);
            aimInCamera.SetActive(true);
        }
        else if (pi == GameManager.m_playerID && isPressed == false)
        {
            mainCamera.SetActive(true);
            aimInCamera.SetActive(false);
        }
    }

    public void PowerShot(int pi, bool isPressed)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        if (pi == GameManager.m_playerID && isPressed == true)
        {
            if (canUseBow)
            {
                GameObject clonedarrow = Instantiate(arrowPrefab, firepoint.position, firepoint.rotation, gameObject.transform);
                canUseBow = false;
                arrowRB = clonedarrow.GetComponent<Rigidbody>();
                arrowRB.isKinematic = false;
                arrowRB.AddForce(clonedarrow.transform.forward * arrowSpeed, ForceMode.Impulse);
            }
        }
    }

    public void DroppingTargets(int pi, bool isPressed)
    {

        if (pi != GameManager.m_playerID && isPressed == true)
        {
            if(canSabotage)
            {
                int range = Random.Range(0, target_Transforms.Count);
                selected_Target = target_Transforms[range];

                selected_Target.Rotate(selected_Target.rotation.x, selected_Target.rotation.y, -90);

                canSabotage = false;
            }
        }
    }

    public void AimDowns(InputAction.CallbackContext context)
    {
        //Debug.Log("Rolling Dice" + context.phase);

        if (context.performed)
        {
            mainCamera.SetActive(false);
            aimInCamera.SetActive(true);
        }
        else if (context.canceled)
        {
            mainCamera.SetActive(true);
            aimInCamera.SetActive(false);
        }
    }

    public void PowerShots(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(canUseBow)
            {
                GameObject clonedarrow = Instantiate(arrowPrefab, firepoint.position, firepoint.rotation, gameObject.transform);
                canUseBow = false;
                arrowRB = clonedarrow.GetComponent<Rigidbody>();
                arrowRB.isKinematic = false;
                arrowRB.AddForce(clonedarrow.transform.forward * arrowSpeed, ForceMode.Impulse);
            }
        }
        if(context.canceled)
        {
            
        }
    }



    public void OnReloadArrow()
    {

    }

    public void TargetHitChecker(bool hasHit)
    {
        if(hasHit)
        {
            amountTargetHit++;
            targetsHitText.text = amountTargetHit.ToString() + "/6";
        }
    }

    private void LoadScene()
    {
        /// TRANSITION ///

        /// LOAD SCENE ///
        SceneManager.LoadScene("Game");

        bool playerStatus = true;
        GameManager.PlayerStatusHandler(playerStatus);

    }

}
 