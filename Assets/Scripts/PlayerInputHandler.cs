using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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
            DiceRolling(obj);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(mover != null)
        {
            mover.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    public void DiceRolling(InputAction.CallbackContext context)
    {
        Debug.Log(context.control + " <-- controller path /// --> Player Index" + playerConfig.PlayerIndex);

        diceController.RollingDice(playerConfig.PlayerIndex, context.ReadValueAsButton());
    }
}
