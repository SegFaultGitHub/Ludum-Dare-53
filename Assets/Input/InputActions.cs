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
    public struct ConveyorsActions
    {
        private @InputActions m_Wrapper;
        public ConveyorsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Drag => m_Wrapper.m_Conveyors_Drag;
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
        }

        private void UnregisterCallbacks(IConveyorsActions instance)
        {
            @Drag.started -= instance.OnDrag;
            @Drag.performed -= instance.OnDrag;
            @Drag.canceled -= instance.OnDrag;
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
    }
}
