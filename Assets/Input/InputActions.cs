//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Globals"",
            ""id"": ""d556ddd8-2765-4aa2-a424-245526b3aff3"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""ca31942f-be24-41ab-8021-56a459653918"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb2b1cc2-347d-46c9-9d4a-8d267ffb6e78"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Conveyors"",
            ""id"": ""4b400cbe-fec1-4b06-87f8-5113bc71b648"",
            ""actions"": [
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""5754d5af-f18d-4192-9446-6827100a8835"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mode: Edition"",
                    ""type"": ""Button"",
                    ""id"": ""d7d70ee2-3351-4462-8223-33f4377841b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mode: Placement"",
                    ""type"": ""Button"",
                    ""id"": ""023d1966-7f3f-44be-b1e2-503dbacec9b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mode: Destruction"",
                    ""type"": ""Button"",
                    ""id"": ""fcdd245d-776f-4cfc-9f3b-4609fc1fca55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f8c7fcc7-20e6-48e9-a8ac-623ec7f88113"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""410672fb-1226-45d3-9b0e-cf0912f75c18"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mode: Edition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""537632ef-8f55-4ddc-8bbb-0b2a846c6b0f"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mode: Placement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ca6857d-c314-4245-afa1-6733ec19fd76"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mode: Destruction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""19f23d41-b5d9-4ed1-8c09-1bc95ff99576"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Button"",
                    ""id"": ""3fd27c48-b885-4636-9e86-9e5d7a0827ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Button"",
                    ""id"": ""0d0d154d-6fd5-4134-8943-99a07ef54729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f8bb7eae-4059-4828-9697-9f9d7ee1359a"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Hold(duration=1.401298E-45)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d9e0cee-5d73-4b4f-91e3-b734f981797c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold(duration=1.401298E-45)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""71f827d5-c924-4ce4-b4e9-1066811f0d21"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""55557cf6-4728-414e-a9d9-d03308f30804"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f17b0eae-6c49-4771-a03c-09c6b95b0b5a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Global"",
            ""bindingGroup"": ""Global"",
            ""devices"": []
        }
    ]
}");
        // Globals
        m_Globals = asset.FindActionMap("Globals", throwIfNotFound: true);
        m_Globals_MousePosition = m_Globals.FindAction("MousePosition", throwIfNotFound: true);
        // Conveyors
        m_Conveyors = asset.FindActionMap("Conveyors", throwIfNotFound: true);
        m_Conveyors_Drag = m_Conveyors.FindAction("Drag", throwIfNotFound: true);
        m_Conveyors_ModeEdition = m_Conveyors.FindAction("Mode: Edition", throwIfNotFound: true);
        m_Conveyors_ModePlacement = m_Conveyors.FindAction("Mode: Placement", throwIfNotFound: true);
        m_Conveyors_ModeDestruction = m_Conveyors.FindAction("Mode: Destruction", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_MoveCamera = m_Camera.FindAction("MoveCamera", throwIfNotFound: true);
        m_Camera_RotateCamera = m_Camera.FindAction("RotateCamera", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Pause = m_Menus.FindAction("Pause", throwIfNotFound: true);
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

    // Globals
    private readonly InputActionMap m_Globals;
    private List<IGlobalsActions> m_GlobalsActionsCallbackInterfaces = new List<IGlobalsActions>();
    private readonly InputAction m_Globals_MousePosition;
    public struct GlobalsActions
    {
        private @InputActions m_Wrapper;
        public GlobalsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Globals_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Globals; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalsActions set) { return set.Get(); }
        public void AddCallbacks(IGlobalsActions instance)
        {
            if (instance == null || m_Wrapper.m_GlobalsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GlobalsActionsCallbackInterfaces.Add(instance);
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
        }

        private void UnregisterCallbacks(IGlobalsActions instance)
        {
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
        }

        public void RemoveCallbacks(IGlobalsActions instance)
        {
            if (m_Wrapper.m_GlobalsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGlobalsActions instance)
        {
            foreach (var item in m_Wrapper.m_GlobalsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GlobalsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GlobalsActions @Globals => new GlobalsActions(this);

    // Conveyors
    private readonly InputActionMap m_Conveyors;
    private List<IConveyorsActions> m_ConveyorsActionsCallbackInterfaces = new List<IConveyorsActions>();
    private readonly InputAction m_Conveyors_Drag;
    private readonly InputAction m_Conveyors_ModeEdition;
    private readonly InputAction m_Conveyors_ModePlacement;
    private readonly InputAction m_Conveyors_ModeDestruction;
    public struct ConveyorsActions
    {
        private @InputActions m_Wrapper;
        public ConveyorsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Drag => m_Wrapper.m_Conveyors_Drag;
        public InputAction @ModeEdition => m_Wrapper.m_Conveyors_ModeEdition;
        public InputAction @ModePlacement => m_Wrapper.m_Conveyors_ModePlacement;
        public InputAction @ModeDestruction => m_Wrapper.m_Conveyors_ModeDestruction;
        public InputActionMap Get() { return m_Wrapper.m_Conveyors; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConveyorsActions set) { return set.Get(); }
        public void AddCallbacks(IConveyorsActions instance)
        {
            if (instance == null || m_Wrapper.m_ConveyorsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ConveyorsActionsCallbackInterfaces.Add(instance);
            @Drag.started += instance.OnDrag;
            @Drag.performed += instance.OnDrag;
            @Drag.canceled += instance.OnDrag;
            @ModeEdition.started += instance.OnModeEdition;
            @ModeEdition.performed += instance.OnModeEdition;
            @ModeEdition.canceled += instance.OnModeEdition;
            @ModePlacement.started += instance.OnModePlacement;
            @ModePlacement.performed += instance.OnModePlacement;
            @ModePlacement.canceled += instance.OnModePlacement;
            @ModeDestruction.started += instance.OnModeDestruction;
            @ModeDestruction.performed += instance.OnModeDestruction;
            @ModeDestruction.canceled += instance.OnModeDestruction;
        }

        private void UnregisterCallbacks(IConveyorsActions instance)
        {
            @Drag.started -= instance.OnDrag;
            @Drag.performed -= instance.OnDrag;
            @Drag.canceled -= instance.OnDrag;
            @ModeEdition.started -= instance.OnModeEdition;
            @ModeEdition.performed -= instance.OnModeEdition;
            @ModeEdition.canceled -= instance.OnModeEdition;
            @ModePlacement.started -= instance.OnModePlacement;
            @ModePlacement.performed -= instance.OnModePlacement;
            @ModePlacement.canceled -= instance.OnModePlacement;
            @ModeDestruction.started -= instance.OnModeDestruction;
            @ModeDestruction.performed -= instance.OnModeDestruction;
            @ModeDestruction.canceled -= instance.OnModeDestruction;
        }

        public void RemoveCallbacks(IConveyorsActions instance)
        {
            if (m_Wrapper.m_ConveyorsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IConveyorsActions instance)
        {
            foreach (var item in m_Wrapper.m_ConveyorsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ConveyorsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ConveyorsActions @Conveyors => new ConveyorsActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_MoveCamera;
    private readonly InputAction m_Camera_RotateCamera;
    public struct CameraActions
    {
        private @InputActions m_Wrapper;
        public CameraActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCamera => m_Wrapper.m_Camera_MoveCamera;
        public InputAction @RotateCamera => m_Wrapper.m_Camera_RotateCamera;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @MoveCamera.started += instance.OnMoveCamera;
            @MoveCamera.performed += instance.OnMoveCamera;
            @MoveCamera.canceled += instance.OnMoveCamera;
            @RotateCamera.started += instance.OnRotateCamera;
            @RotateCamera.performed += instance.OnRotateCamera;
            @RotateCamera.canceled += instance.OnRotateCamera;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @MoveCamera.started -= instance.OnMoveCamera;
            @MoveCamera.performed -= instance.OnMoveCamera;
            @MoveCamera.canceled -= instance.OnMoveCamera;
            @RotateCamera.started -= instance.OnRotateCamera;
            @RotateCamera.performed -= instance.OnRotateCamera;
            @RotateCamera.canceled -= instance.OnRotateCamera;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private List<IMenusActions> m_MenusActionsCallbackInterfaces = new List<IMenusActions>();
    private readonly InputAction m_Menus_Pause;
    public struct MenusActions
    {
        private @InputActions m_Wrapper;
        public MenusActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Menus_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void AddCallbacks(IMenusActions instance)
        {
            if (instance == null || m_Wrapper.m_MenusActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenusActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IMenusActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenusActions instance)
        {
            foreach (var item in m_Wrapper.m_MenusActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenusActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenusActions @Menus => new MenusActions(this);
    private int m_GlobalSchemeIndex = -1;
    public InputControlScheme GlobalScheme
    {
        get
        {
            if (m_GlobalSchemeIndex == -1) m_GlobalSchemeIndex = asset.FindControlSchemeIndex("Global");
            return asset.controlSchemes[m_GlobalSchemeIndex];
        }
    }
    public interface IGlobalsActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IConveyorsActions
    {
        void OnDrag(InputAction.CallbackContext context);
        void OnModeEdition(InputAction.CallbackContext context);
        void OnModePlacement(InputAction.CallbackContext context);
        void OnModeDestruction(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
