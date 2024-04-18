//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Misc/PlayerController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Dice Rolling"",
            ""id"": ""bf7f7671-08d9-4f36-aa42-630537f6c6bd"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""d4538eb8-851d-47de-9587-02ffc3b42b0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45aa2c62-c9bb-46d5-b4d2-952c05a427b2"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""db12090b-636b-4c20-b4a9-bc05148f5cfa"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""beb1690c-c3aa-4c3c-b17a-ecae5cec6d92"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8276aa41-d6b0-47b1-b8c1-83b7954c593e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RollDice"",
                    ""type"": ""Button"",
                    ""id"": ""61ab7cac-35bc-496b-ae0a-028896dc30c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""de83b970-e0b0-4a23-9120-bf9506ada664"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""81d48e3c-8a99-4150-b386-7d14b60dde89"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57b86c9a-86be-48b6-9d32-a287ee2b20c8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5de14624-1143-4694-8e36-b737929c067a"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5cfa437-f6e7-469a-9646-cf3d0ff65b77"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c7c7764-af3c-4e3a-a59f-414bd5f3bcf1"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollDice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edc1b02d-a336-4b46-b48f-80e9465ffffb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9a85cb9-ec0f-4aa2-ae25-98c705d09777"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Dice Rolling
        m_DiceRolling = asset.FindActionMap("Dice Rolling", throwIfNotFound: true);
        m_DiceRolling_Roll = m_DiceRolling.FindAction("Roll", throwIfNotFound: true);
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Select = m_PlayerMovement.FindAction("Select", throwIfNotFound: true);
        m_PlayerMovement_RollDice = m_PlayerMovement.FindAction("RollDice", throwIfNotFound: true);
        m_PlayerMovement_LeftTrigger = m_PlayerMovement.FindAction("LeftTrigger", throwIfNotFound: true);
        m_PlayerMovement_RightTrigger = m_PlayerMovement.FindAction("RightTrigger", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Dice Rolling
    private readonly InputActionMap m_DiceRolling;
    private List<IDiceRollingActions> m_DiceRollingActionsCallbackInterfaces = new List<IDiceRollingActions>();
    private readonly InputAction m_DiceRolling_Roll;
    public struct DiceRollingActions
    {
        private @PlayerController m_Wrapper;
        public DiceRollingActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_DiceRolling_Roll;
        public InputActionMap Get() { return m_Wrapper.m_DiceRolling; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DiceRollingActions set) { return set.Get(); }
        public void AddCallbacks(IDiceRollingActions instance)
        {
            if (instance == null || m_Wrapper.m_DiceRollingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DiceRollingActionsCallbackInterfaces.Add(instance);
            @Roll.started += instance.OnRoll;
            @Roll.performed += instance.OnRoll;
            @Roll.canceled += instance.OnRoll;
        }

        private void UnregisterCallbacks(IDiceRollingActions instance)
        {
            @Roll.started -= instance.OnRoll;
            @Roll.performed -= instance.OnRoll;
            @Roll.canceled -= instance.OnRoll;
        }

        public void RemoveCallbacks(IDiceRollingActions instance)
        {
            if (m_Wrapper.m_DiceRollingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDiceRollingActions instance)
        {
            foreach (var item in m_Wrapper.m_DiceRollingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DiceRollingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DiceRollingActions @DiceRolling => new DiceRollingActions(this);

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private List<IPlayerMovementActions> m_PlayerMovementActionsCallbackInterfaces = new List<IPlayerMovementActions>();
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Select;
    private readonly InputAction m_PlayerMovement_RollDice;
    private readonly InputAction m_PlayerMovement_LeftTrigger;
    private readonly InputAction m_PlayerMovement_RightTrigger;
    public struct PlayerMovementActions
    {
        private @PlayerController m_Wrapper;
        public PlayerMovementActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Select => m_Wrapper.m_PlayerMovement_Select;
        public InputAction @RollDice => m_Wrapper.m_PlayerMovement_RollDice;
        public InputAction @LeftTrigger => m_Wrapper.m_PlayerMovement_LeftTrigger;
        public InputAction @RightTrigger => m_Wrapper.m_PlayerMovement_RightTrigger;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @RollDice.started += instance.OnRollDice;
            @RollDice.performed += instance.OnRollDice;
            @RollDice.canceled += instance.OnRollDice;
            @LeftTrigger.started += instance.OnLeftTrigger;
            @LeftTrigger.performed += instance.OnLeftTrigger;
            @LeftTrigger.canceled += instance.OnLeftTrigger;
            @RightTrigger.started += instance.OnRightTrigger;
            @RightTrigger.performed += instance.OnRightTrigger;
            @RightTrigger.canceled += instance.OnRightTrigger;
        }

        private void UnregisterCallbacks(IPlayerMovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @RollDice.started -= instance.OnRollDice;
            @RollDice.performed -= instance.OnRollDice;
            @RollDice.canceled -= instance.OnRollDice;
            @LeftTrigger.started -= instance.OnLeftTrigger;
            @LeftTrigger.performed -= instance.OnLeftTrigger;
            @LeftTrigger.canceled -= instance.OnLeftTrigger;
            @RightTrigger.started -= instance.OnRightTrigger;
            @RightTrigger.performed -= instance.OnRightTrigger;
            @RightTrigger.canceled -= instance.OnRightTrigger;
        }

        public void RemoveCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IDiceRollingActions
    {
        void OnRoll(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnRollDice(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
    }
}
