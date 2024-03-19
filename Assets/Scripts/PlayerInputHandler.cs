using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerInput playerInput;
    private Mover2 mover;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover2>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(mover != null)
        {
            mover.SetInputVector(context.ReadValue<Vector2>());
        }
    }
}
