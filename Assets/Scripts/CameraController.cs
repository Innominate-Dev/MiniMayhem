using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector2 bowInput;

    [Header("Variables & Camera Speeds")]

    [SerializeField]
    private float cameraSpeed = 10f;
    [SerializeField]
    private float lookSpeed = 100f;
    [SerializeField]
    private float bowSpeed = 10f;

    private bool settedUpInput;

    public Transform cameraTransform;
    public Transform bowTransform;

    [Header("Player Inputs")]

    public PlayerInput[] pi_list;

    public PlayerInput moveAction;
    public PlayerInput lookAction;
    public PlayerInput bowAction;

    [Header("Player Properties")]

    [SerializeField] private int playerID;

    GameManager gameManager;

    private void Awake()
    {        
        bowTransform = GameObject.FindWithTag("Bow").transform;
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context, int pi)
    {
        if(pi == gameManager.m_playerID)
        {
            lookInput = context.ReadValue<Vector2>();
        }
    }

    public void OnBow(InputAction.CallbackContext context)
    {
        bowInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if(settedUpInput == false)
        {
            SettingPlayerInputs();
        }


        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        cameraTransform.position += moveDir * cameraSpeed * Time.deltaTime;

        Vector2 lookDir = lookInput * lookSpeed * Time.deltaTime;
        cameraTransform.Rotate(Vector3.up, lookDir.x);
        bowTransform.Rotate(-Vector3.right, lookDir.y);

        bowTransform.position += bowTransform.forward * bowInput.y * bowSpeed * Time.deltaTime;
    }

    void SettingPlayerInputs()
    {
        if (pi_list == null || pi_list.Length == 0)
        {
            pi_list = FindObjectsOfType<PlayerInput>();
        }

        if(pi_list != null || pi_list.Length != 0)
        {
            for (int i = 0; i < pi_list.Length; i++)
            {
                Debug.Log(pi_list[i].user.id + " " + gameManager.m_playerID);
                int playerid = gameManager.m_playerID;
                playerid++;
                if (pi_list[i].user.id == playerid)
                {
                    Debug.Log("Found the player");
                    moveAction = pi_list[i];
                    lookAction = pi_list[i];
                    bowAction = pi_list[i];
                    settedUpInput = true;
                }
                else
                {
                    Debug.Log("couldn't find the player");
                }
            }
        }
    }
}