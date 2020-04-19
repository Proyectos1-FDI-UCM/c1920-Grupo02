// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""35020fc6-bdfc-46ba-be8f-de4a2d1e958d"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f88e0f19-771f-4345-a63d-29fee1ee2920"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""231505b8-4010-4503-80ee-3747456d2213"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""2d2c58e2-3d09-4b9f-a99e-b5f784ab1eec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""2a5da699-2538-4911-a7ab-0eaa25d56f50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootOrDash"",
                    ""type"": ""Button"",
                    ""id"": ""db494979-896b-4983-abd9-fac936aed6d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AtqMelee"",
                    ""type"": ""Button"",
                    ""id"": ""6054bb17-ad63-4ee8-a0d2-424f8cdaa686"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1)""
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5a205b4b-f312-4bf8-990b-6a82adbf69f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Controles"",
                    ""type"": ""Button"",
                    ""id"": ""390ec999-aa53-415e-b6ed-676bc5c02b54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ef00a41c-f03a-45dd-843e-05972fa68c88"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c11cb208-2f8a-458d-9454-2463fc017a36"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6274ee2e-1505-40bc-aa2b-8fe2a750f434"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""8016ea67-e7f7-46fe-a989-f6683ed3be88"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""60fbeea2-5e82-4881-bbb0-73304317bee0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e53bf03e-05f3-46df-b1ec-ac9b95068fe2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c9ec70a-0810-4f3d-9305-b9f13ee4c4b3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""282cfffc-b21d-4a2a-946d-2e5b4a55c167"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1c03f17-69d4-46b5-a859-26fb6ea1090c"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6d3217d-1769-4aa1-904b-2e3383337ce6"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89d91e59-ebec-486d-a1d2-02ccc8b207ad"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootOrDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b22425f-fa3a-43ca-9891-6d00c1d921cf"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootOrDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20eb6c94-d0be-49a3-b5ce-ae7f30302714"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtqMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5cc3c88-5aaf-443d-8bad-3aa5a01fa9b8"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AtqMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b49c0c94-ec8f-477a-8a4e-c8f6d27851d7"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Controles"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bbf129b-6728-422c-b9f0-59754fa05592"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Horizontal = m_PlayerControls.FindAction("Horizontal", throwIfNotFound: true);
        m_PlayerControls_Vertical = m_PlayerControls.FindAction("Vertical", throwIfNotFound: true);
        m_PlayerControls_NextCharacter = m_PlayerControls.FindAction("NextCharacter", throwIfNotFound: true);
        m_PlayerControls_PrevCharacter = m_PlayerControls.FindAction("PrevCharacter", throwIfNotFound: true);
        m_PlayerControls_ShootOrDash = m_PlayerControls.FindAction("ShootOrDash", throwIfNotFound: true);
        m_PlayerControls_AtqMelee = m_PlayerControls.FindAction("AtqMelee", throwIfNotFound: true);
        m_PlayerControls_Cancel = m_PlayerControls.FindAction("Cancel", throwIfNotFound: true);
        m_PlayerControls_Controles = m_PlayerControls.FindAction("Controles", throwIfNotFound: true);
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

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Horizontal;
    private readonly InputAction m_PlayerControls_Vertical;
    private readonly InputAction m_PlayerControls_NextCharacter;
    private readonly InputAction m_PlayerControls_PrevCharacter;
    private readonly InputAction m_PlayerControls_ShootOrDash;
    private readonly InputAction m_PlayerControls_AtqMelee;
    private readonly InputAction m_PlayerControls_Cancel;
    private readonly InputAction m_PlayerControls_Controles;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_PlayerControls_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_PlayerControls_Vertical;
        public InputAction @NextCharacter => m_Wrapper.m_PlayerControls_NextCharacter;
        public InputAction @PrevCharacter => m_Wrapper.m_PlayerControls_PrevCharacter;
        public InputAction @ShootOrDash => m_Wrapper.m_PlayerControls_ShootOrDash;
        public InputAction @AtqMelee => m_Wrapper.m_PlayerControls_AtqMelee;
        public InputAction @Cancel => m_Wrapper.m_PlayerControls_Cancel;
        public InputAction @Controles => m_Wrapper.m_PlayerControls_Controles;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnVertical;
                @NextCharacter.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextCharacter;
                @NextCharacter.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextCharacter;
                @NextCharacter.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextCharacter;
                @PrevCharacter.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrevCharacter;
                @PrevCharacter.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrevCharacter;
                @PrevCharacter.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrevCharacter;
                @ShootOrDash.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootOrDash;
                @ShootOrDash.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootOrDash;
                @ShootOrDash.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootOrDash;
                @AtqMelee.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAtqMelee;
                @AtqMelee.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAtqMelee;
                @AtqMelee.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAtqMelee;
                @Cancel.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCancel;
                @Controles.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnControles;
                @Controles.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnControles;
                @Controles.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnControles;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @NextCharacter.started += instance.OnNextCharacter;
                @NextCharacter.performed += instance.OnNextCharacter;
                @NextCharacter.canceled += instance.OnNextCharacter;
                @PrevCharacter.started += instance.OnPrevCharacter;
                @PrevCharacter.performed += instance.OnPrevCharacter;
                @PrevCharacter.canceled += instance.OnPrevCharacter;
                @ShootOrDash.started += instance.OnShootOrDash;
                @ShootOrDash.performed += instance.OnShootOrDash;
                @ShootOrDash.canceled += instance.OnShootOrDash;
                @AtqMelee.started += instance.OnAtqMelee;
                @AtqMelee.performed += instance.OnAtqMelee;
                @AtqMelee.canceled += instance.OnAtqMelee;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Controles.started += instance.OnControles;
                @Controles.performed += instance.OnControles;
                @Controles.canceled += instance.OnControles;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnNextCharacter(InputAction.CallbackContext context);
        void OnPrevCharacter(InputAction.CallbackContext context);
        void OnShootOrDash(InputAction.CallbackContext context);
        void OnAtqMelee(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnControles(InputAction.CallbackContext context);
    }
}
