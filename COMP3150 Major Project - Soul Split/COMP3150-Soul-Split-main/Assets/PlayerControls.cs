//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""bfbddb55-2e91-4357-957d-67932db76a85"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""83815bc4-a531-4270-8c82-e48013e4a542"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4fd146f8-d776-4c5a-b222-b8e4cf931e61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ProjectSoul"",
                    ""type"": ""Button"",
                    ""id"": ""cc294644-725f-400d-b24d-cab888afa6a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftingSoul"",
                    ""type"": ""Button"",
                    ""id"": ""523b1553-9578-4748-b2f6-2e70e406c0d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StillSoul"",
                    ""type"": ""Button"",
                    ""id"": ""791ca6f8-2d40-47bd-942a-c02a393ab72f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SoulAbsorb"",
                    ""type"": ""Button"",
                    ""id"": ""e0c9c579-5ac0-41a0-8370-d164be4a5db3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SoulSwap"",
                    ""type"": ""Button"",
                    ""id"": ""67cbd1be-4616-4430-a104-a0cf3c6e0f85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SoulMaterialise"",
                    ""type"": ""Button"",
                    ""id"": ""f70dc254-8176-4064-b774-fe7e68b03e30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleSoul"",
                    ""type"": ""Button"",
                    ""id"": ""ee41519f-9c92-44ed-b2b4-df6ddbc17f8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ProjectionAimController"",
                    ""type"": ""Value"",
                    ""id"": ""8c541db9-8640-46b1-88b6-385654d85f89"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""9d3eecd3-7497-4717-89b1-a5b1ec64f014"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseScrollY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c2dfdbb4-0ad5-4708-ba34-4289f0defc49"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EnterGame"",
                    ""type"": ""Button"",
                    ""id"": ""9dffd966-8856-4921-9d5a-019eee31cfd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""98df356a-be8e-40f2-b8a4-caaee09b4c7b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3b64b00-6790-49e2-8379-b6b57e40627d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b6e642a3-49b6-4e4e-a421-0cefe06ef545"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""02995ab8-75c0-4022-b72d-b6057093868b"",
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
                    ""id"": ""c8187af0-3b8c-4e84-b40f-da9e134664df"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35771ee-009f-478d-80b1-61eb5ea52ba7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f3c76f9-8390-44f8-bfa7-7baa0f62a062"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ProjectSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2232cbb-d442-455d-8319-6c85ef0f106a"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ProjectSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07b90eb7-5146-4891-b57f-c6e33465da2a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftingSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d14abd37-269a-4d0c-ab3f-11128439325d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftingSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""648616be-4806-43e8-a1fe-5b97466db6f2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StillSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""660201f4-e0ec-4e18-bc55-63d42232dbb6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StillSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f805d725-7cb1-489b-bbce-3849904086b6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulAbsorb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0135052-afaa-4f8d-a0d2-06a23498841f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulAbsorb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db0e2493-3c85-4628-bdcd-2fdff8dee678"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulSwap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41f4b550-6189-41dc-ab25-3c7b7d61b851"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulSwap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32f19e9f-70ac-4b29-85ad-d5ed68dbd52d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulMaterialise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46de0886-6ab4-4cdd-871f-8c13cb788708"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoulMaterialise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93e45885-ae72-48ed-b2d3-cde67079cb40"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e3b7b56-f1d6-4602-8306-c37c47f85428"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSoul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd1214fa-e219-49a0-886d-64c350667572"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ProjectionAimController"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09ef0d54-a91a-4d2a-8f7b-823b7ce6cb00"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a1d10fc-7b85-4629-9dff-d797d8f98ef8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e15f13cf-6edb-4c43-84c2-9928a11191d6"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScrollY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc6228b2-6211-4f02-bfc0-a568b0a8c55f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebed34f0-6118-4965-8685-f5017a2cffa5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""d617f4c0-8557-4295-a83c-d2f909af0811"",
            ""actions"": [
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""ac6a9011-daf3-45c4-89d1-3054da1150ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e236b8ff-738a-4290-b7fc-a296f860090b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Testing"",
            ""id"": ""adfea43c-479b-4a9c-bcae-77b6e1fb5f11"",
            ""actions"": [
                {
                    ""name"": ""LevelChange"",
                    ""type"": ""Button"",
                    ""id"": ""9a12e475-6529-4c7c-b655-55fed9111e7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b163fb9-e928-4de0-b85e-38d7993158dd"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LevelChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_ProjectSoul = m_Gameplay.FindAction("ProjectSoul", throwIfNotFound: true);
        m_Gameplay_ShiftingSoul = m_Gameplay.FindAction("ShiftingSoul", throwIfNotFound: true);
        m_Gameplay_StillSoul = m_Gameplay.FindAction("StillSoul", throwIfNotFound: true);
        m_Gameplay_SoulAbsorb = m_Gameplay.FindAction("SoulAbsorb", throwIfNotFound: true);
        m_Gameplay_SoulSwap = m_Gameplay.FindAction("SoulSwap", throwIfNotFound: true);
        m_Gameplay_SoulMaterialise = m_Gameplay.FindAction("SoulMaterialise", throwIfNotFound: true);
        m_Gameplay_ToggleSoul = m_Gameplay.FindAction("ToggleSoul", throwIfNotFound: true);
        m_Gameplay_ProjectionAimController = m_Gameplay.FindAction("ProjectionAimController", throwIfNotFound: true);
        m_Gameplay_PauseGame = m_Gameplay.FindAction("PauseGame", throwIfNotFound: true);
        m_Gameplay_MouseScrollY = m_Gameplay.FindAction("MouseScrollY", throwIfNotFound: true);
        m_Gameplay_EnterGame = m_Gameplay.FindAction("EnterGame", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MousePos = m_Mouse.FindAction("MousePos", throwIfNotFound: true);
        // Testing
        m_Testing = asset.FindActionMap("Testing", throwIfNotFound: true);
        m_Testing_LevelChange = m_Testing.FindAction("LevelChange", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_ProjectSoul;
    private readonly InputAction m_Gameplay_ShiftingSoul;
    private readonly InputAction m_Gameplay_StillSoul;
    private readonly InputAction m_Gameplay_SoulAbsorb;
    private readonly InputAction m_Gameplay_SoulSwap;
    private readonly InputAction m_Gameplay_SoulMaterialise;
    private readonly InputAction m_Gameplay_ToggleSoul;
    private readonly InputAction m_Gameplay_ProjectionAimController;
    private readonly InputAction m_Gameplay_PauseGame;
    private readonly InputAction m_Gameplay_MouseScrollY;
    private readonly InputAction m_Gameplay_EnterGame;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @ProjectSoul => m_Wrapper.m_Gameplay_ProjectSoul;
        public InputAction @ShiftingSoul => m_Wrapper.m_Gameplay_ShiftingSoul;
        public InputAction @StillSoul => m_Wrapper.m_Gameplay_StillSoul;
        public InputAction @SoulAbsorb => m_Wrapper.m_Gameplay_SoulAbsorb;
        public InputAction @SoulSwap => m_Wrapper.m_Gameplay_SoulSwap;
        public InputAction @SoulMaterialise => m_Wrapper.m_Gameplay_SoulMaterialise;
        public InputAction @ToggleSoul => m_Wrapper.m_Gameplay_ToggleSoul;
        public InputAction @ProjectionAimController => m_Wrapper.m_Gameplay_ProjectionAimController;
        public InputAction @PauseGame => m_Wrapper.m_Gameplay_PauseGame;
        public InputAction @MouseScrollY => m_Wrapper.m_Gameplay_MouseScrollY;
        public InputAction @EnterGame => m_Wrapper.m_Gameplay_EnterGame;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @ProjectSoul.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectSoul;
                @ProjectSoul.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectSoul;
                @ProjectSoul.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectSoul;
                @ShiftingSoul.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShiftingSoul;
                @ShiftingSoul.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShiftingSoul;
                @ShiftingSoul.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShiftingSoul;
                @StillSoul.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStillSoul;
                @StillSoul.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStillSoul;
                @StillSoul.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStillSoul;
                @SoulAbsorb.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulAbsorb;
                @SoulAbsorb.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulAbsorb;
                @SoulAbsorb.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulAbsorb;
                @SoulSwap.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulSwap;
                @SoulSwap.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulSwap;
                @SoulSwap.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulSwap;
                @SoulMaterialise.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulMaterialise;
                @SoulMaterialise.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulMaterialise;
                @SoulMaterialise.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoulMaterialise;
                @ToggleSoul.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleSoul;
                @ToggleSoul.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleSoul;
                @ToggleSoul.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleSoul;
                @ProjectionAimController.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectionAimController;
                @ProjectionAimController.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectionAimController;
                @ProjectionAimController.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnProjectionAimController;
                @PauseGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPauseGame;
                @MouseScrollY.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollY;
                @MouseScrollY.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollY;
                @MouseScrollY.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollY;
                @EnterGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterGame;
                @EnterGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterGame;
                @EnterGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterGame;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ProjectSoul.started += instance.OnProjectSoul;
                @ProjectSoul.performed += instance.OnProjectSoul;
                @ProjectSoul.canceled += instance.OnProjectSoul;
                @ShiftingSoul.started += instance.OnShiftingSoul;
                @ShiftingSoul.performed += instance.OnShiftingSoul;
                @ShiftingSoul.canceled += instance.OnShiftingSoul;
                @StillSoul.started += instance.OnStillSoul;
                @StillSoul.performed += instance.OnStillSoul;
                @StillSoul.canceled += instance.OnStillSoul;
                @SoulAbsorb.started += instance.OnSoulAbsorb;
                @SoulAbsorb.performed += instance.OnSoulAbsorb;
                @SoulAbsorb.canceled += instance.OnSoulAbsorb;
                @SoulSwap.started += instance.OnSoulSwap;
                @SoulSwap.performed += instance.OnSoulSwap;
                @SoulSwap.canceled += instance.OnSoulSwap;
                @SoulMaterialise.started += instance.OnSoulMaterialise;
                @SoulMaterialise.performed += instance.OnSoulMaterialise;
                @SoulMaterialise.canceled += instance.OnSoulMaterialise;
                @ToggleSoul.started += instance.OnToggleSoul;
                @ToggleSoul.performed += instance.OnToggleSoul;
                @ToggleSoul.canceled += instance.OnToggleSoul;
                @ProjectionAimController.started += instance.OnProjectionAimController;
                @ProjectionAimController.performed += instance.OnProjectionAimController;
                @ProjectionAimController.canceled += instance.OnProjectionAimController;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @MouseScrollY.started += instance.OnMouseScrollY;
                @MouseScrollY.performed += instance.OnMouseScrollY;
                @MouseScrollY.canceled += instance.OnMouseScrollY;
                @EnterGame.started += instance.OnEnterGame;
                @EnterGame.performed += instance.OnEnterGame;
                @EnterGame.canceled += instance.OnEnterGame;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MousePos;
    public struct MouseActions
    {
        private @PlayerControls m_Wrapper;
        public MouseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePos => m_Wrapper.m_Mouse_MousePos;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MousePos.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Testing
    private readonly InputActionMap m_Testing;
    private ITestingActions m_TestingActionsCallbackInterface;
    private readonly InputAction m_Testing_LevelChange;
    public struct TestingActions
    {
        private @PlayerControls m_Wrapper;
        public TestingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LevelChange => m_Wrapper.m_Testing_LevelChange;
        public InputActionMap Get() { return m_Wrapper.m_Testing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestingActions set) { return set.Get(); }
        public void SetCallbacks(ITestingActions instance)
        {
            if (m_Wrapper.m_TestingActionsCallbackInterface != null)
            {
                @LevelChange.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnLevelChange;
                @LevelChange.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnLevelChange;
                @LevelChange.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnLevelChange;
            }
            m_Wrapper.m_TestingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LevelChange.started += instance.OnLevelChange;
                @LevelChange.performed += instance.OnLevelChange;
                @LevelChange.canceled += instance.OnLevelChange;
            }
        }
    }
    public TestingActions @Testing => new TestingActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnProjectSoul(InputAction.CallbackContext context);
        void OnShiftingSoul(InputAction.CallbackContext context);
        void OnStillSoul(InputAction.CallbackContext context);
        void OnSoulAbsorb(InputAction.CallbackContext context);
        void OnSoulSwap(InputAction.CallbackContext context);
        void OnSoulMaterialise(InputAction.CallbackContext context);
        void OnToggleSoul(InputAction.CallbackContext context);
        void OnProjectionAimController(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnMouseScrollY(InputAction.CallbackContext context);
        void OnEnterGame(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnMousePos(InputAction.CallbackContext context);
    }
    public interface ITestingActions
    {
        void OnLevelChange(InputAction.CallbackContext context);
    }
}
