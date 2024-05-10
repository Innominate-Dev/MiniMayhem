using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerConfiguration playerConfig;
    private Mover2 mover;
    private DiceController diceController;

    [SerializeField]
    private MeshRenderer playerMesh;

    private PlayerController controls; 

    private void Awake()
    {
        mover = GetComponent<Mover2>();
        controls = new PlayerController();
        diceController = FindAnyObjectByType<DiceController>();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerMesh.material = pc.PlayerMaterial;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(InputAction.CallbackContext obj)
    {
        if(obj.action.name == controls.PlayerMovement.Movement.name)
        {
            OnMove(obj);
        }
        if(obj.action.name == controls.PlayerMovement.RollDice.name)
        {
            InteractionButton(obj);
        }
        if(obj.action.name == controls.PlayerMovement.LeftTrigger.name)
        {
            LeftTriggerPressed(obj);
        }
        if(obj.action.name == controls.PlayerMovement.RightTrigger.name)
        {
            RightTriggerPressed(obj);
        }
        if(obj.action.name == controls.PlayerMovement.Look.name)
        {
            OnLook(obj);
        }
        if(obj.action.name == controls.PlayerMovement.DecreaseNum.name)
        {
            DecreaseNum(obj);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(mover != null)
        {
            mover.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
        CameraController camController = GameObject.FindObjectOfType<CameraController>();
        if(camController != null)
        {
            camController.OnLook(context, playerConfig.PlayerIndex);
        }
    }

    public void DecreaseNum(InputAction.CallbackContext context)
    {
        // On Button B pressed or Square //

        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if(sceneName == "CountTheEggs")
        {
            CountTheEggs minigamesScript = GameObject.Find("MinigameManager").GetComponent<CountTheEggs>();

            minigamesScript.DecreaseGuessNum(playerConfig.PlayerIndex, context.ReadValueAsButton());
        }
    }

    public void InteractionButton(InputAction.CallbackContext context)
    {
        // On Button A pressed or X //

        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if(sceneName == "Game")
        {
            diceController.RollingDice(playerConfig.PlayerIndex, context.ReadValueAsButton());
        }
        if (sceneName == "HitTheTarget")
        {
            HitTheTarget minigameScript = GameObject.Find("MinigameManager").GetComponent<HitTheTarget>();

            minigameScript.DroppingTargets(playerConfig.PlayerIndex, context.ReadValueAsButton());
        }
        if(sceneName == "CountTheEggs")
        {
            CountTheEggs minigamesScript = GameObject.Find("MinigameManager").GetComponent<CountTheEggs>();

            minigamesScript.IncreaseGuessNum(playerConfig.PlayerIndex, context.ReadValueAsButton());
            minigamesScript.SabotagePlayer(playerConfig.PlayerIndex, context.ReadValueAsButton());
        }
    }

    public void LeftTriggerPressed(InputAction.CallbackContext context)
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if(sceneName == "HitTheTarget")
        {
            HitTheTarget minigameScript = GameObject.Find("MinigameManager").GetComponent<HitTheTarget>();

            minigameScript.AimDown(playerConfig.PlayerIndex, context.ReadValueAsButton());

        }
    }    
    
    public void RightTriggerPressed(InputAction.CallbackContext context)
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "HitTheTarget")
        {
            HitTheTarget minigameScript = GameObject.Find("MinigameManager").GetComponent<HitTheTarget>();

            minigameScript.PowerShot(playerConfig.PlayerIndex, context.ReadValueAsButton());

        }
    }
}
