// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerMovement.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMovement : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovement"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""cac67626-e879-424e-a909-2a0794e11d64"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d91cc0e-76dd-40bd-89ee-70f4a4e7394b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""94f481cc-c554-4f98-aa0e-497e1d305a84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f30fce9a-1d12-4504-be26-9364937d4846"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mute"",
                    ""type"": ""Button"",
                    ""id"": ""dd617364-6f4d-4901-a07b-9be41a923cb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""bb23e60c-0a96-411b-ac2f-502b2a536e84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SwitchAttackLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c41fe254-ee4e-470c-868d-f793fe55ec33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SwitchAttackRight"",
                    ""type"": ""Button"",
                    ""id"": ""a8a690d8-95c7-4466-b4ff-c84868d34307"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba906e6f-f24f-466e-95b4-d7f90d74b4d3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c89c7911-12b5-48dc-a06c-cb6ab3b19e67"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e5cece70-bd7f-48c7-9cac-bbb2df1cca93"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e445041-775d-44e7-b588-3e22d74b4827"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c8fac481-b4c7-4db9-8d19-9268351ebf05"",
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
                    ""id"": ""9ad35c08-b3e2-4335-8e40-cc23383dd1bc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c5da361c-ff67-4ee0-9cd2-4cddea3c49e5"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5706633f-71eb-4477-8028-69d3dd8278df"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4629da26-dcff-4838-80f4-5537e789dc7b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8050812d-8277-4098-9152-3a1352c56fcb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""14a36413-6242-4fd9-b48b-0ed171ce49aa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9c0a545b-74b3-4687-9c3c-879d5cf39cb8"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""628e4e3a-962c-4591-a392-6320b4bf1900"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c556e658-d280-4632-8227-3a81dd7606bc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchAttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71650ea8-5778-4cb8-8bc5-8c44fb030891"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchAttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Movement = m_Main.FindAction("Movement", throwIfNotFound: true);
        m_Main_Attack = m_Main.FindAction("Attack", throwIfNotFound: true);
        m_Main_Rotate = m_Main.FindAction("Rotate", throwIfNotFound: true);
        m_Main_Mute = m_Main.FindAction("Mute", throwIfNotFound: true);
        m_Main_Quit = m_Main.FindAction("Quit", throwIfNotFound: true);
        m_Main_SwitchAttackLeft = m_Main.FindAction("SwitchAttackLeft", throwIfNotFound: true);
        m_Main_SwitchAttackRight = m_Main.FindAction("SwitchAttackRight", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Movement;
    private readonly InputAction m_Main_Attack;
    private readonly InputAction m_Main_Rotate;
    private readonly InputAction m_Main_Mute;
    private readonly InputAction m_Main_Quit;
    private readonly InputAction m_Main_SwitchAttackLeft;
    private readonly InputAction m_Main_SwitchAttackRight;
    public struct MainActions
    {
        private @PlayerMovement m_Wrapper;
        public MainActions(@PlayerMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Main_Movement;
        public InputAction @Attack => m_Wrapper.m_Main_Attack;
        public InputAction @Rotate => m_Wrapper.m_Main_Rotate;
        public InputAction @Mute => m_Wrapper.m_Main_Mute;
        public InputAction @Quit => m_Wrapper.m_Main_Quit;
        public InputAction @SwitchAttackLeft => m_Wrapper.m_Main_SwitchAttackLeft;
        public InputAction @SwitchAttackRight => m_Wrapper.m_Main_SwitchAttackRight;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAttack;
                @Rotate.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRotate;
                @Mute.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMute;
                @Mute.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMute;
                @Mute.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMute;
                @Quit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @SwitchAttackLeft.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackLeft;
                @SwitchAttackLeft.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackLeft;
                @SwitchAttackLeft.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackLeft;
                @SwitchAttackRight.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackRight;
                @SwitchAttackRight.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackRight;
                @SwitchAttackRight.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSwitchAttackRight;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Mute.started += instance.OnMute;
                @Mute.performed += instance.OnMute;
                @Mute.canceled += instance.OnMute;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @SwitchAttackLeft.started += instance.OnSwitchAttackLeft;
                @SwitchAttackLeft.performed += instance.OnSwitchAttackLeft;
                @SwitchAttackLeft.canceled += instance.OnSwitchAttackLeft;
                @SwitchAttackRight.started += instance.OnSwitchAttackRight;
                @SwitchAttackRight.performed += instance.OnSwitchAttackRight;
                @SwitchAttackRight.canceled += instance.OnSwitchAttackRight;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnMute(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnSwitchAttackLeft(InputAction.CallbackContext context);
        void OnSwitchAttackRight(InputAction.CallbackContext context);
    }
}
