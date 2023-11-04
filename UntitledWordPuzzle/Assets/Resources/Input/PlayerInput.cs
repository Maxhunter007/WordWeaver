//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/Input/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""937582cf-9b43-475c-93a1-ddeaa943d2af"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""Value"",
                    ""id"": ""379f5904-60df-47e0-b02d-7a94717cb12e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PickupLetter"",
                    ""type"": ""Button"",
                    ""id"": ""e3dc9761-d285-41db-af98-37d3b4da3aa9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLetter"",
                    ""type"": ""Value"",
                    ""id"": ""03eca443-c986-4d4d-9e7b-1be0e5d7dc1d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3173c9d9-0238-440a-9869-d7603e8166b8"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65d04a22-45e7-405a-8b25-1dc6ecac19b4"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickupLetter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54e0f00a-338c-48c5-9c57-ab49a5249d7e"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLetter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Pan = m_Input.FindAction("Pan", throwIfNotFound: true);
        m_Input_PickupLetter = m_Input.FindAction("PickupLetter", throwIfNotFound: true);
        m_Input_MoveLetter = m_Input.FindAction("MoveLetter", throwIfNotFound: true);
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

    // Input
    private readonly InputActionMap m_Input;
    private List<IInputActions> m_InputActionsCallbackInterfaces = new List<IInputActions>();
    private readonly InputAction m_Input_Pan;
    private readonly InputAction m_Input_PickupLetter;
    private readonly InputAction m_Input_MoveLetter;
    public struct InputActions
    {
        private @PlayerInput m_Wrapper;
        public InputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_Input_Pan;
        public InputAction @PickupLetter => m_Wrapper.m_Input_PickupLetter;
        public InputAction @MoveLetter => m_Wrapper.m_Input_MoveLetter;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void AddCallbacks(IInputActions instance)
        {
            if (instance == null || m_Wrapper.m_InputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputActionsCallbackInterfaces.Add(instance);
            @Pan.started += instance.OnPan;
            @Pan.performed += instance.OnPan;
            @Pan.canceled += instance.OnPan;
            @PickupLetter.started += instance.OnPickupLetter;
            @PickupLetter.performed += instance.OnPickupLetter;
            @PickupLetter.canceled += instance.OnPickupLetter;
            @MoveLetter.started += instance.OnMoveLetter;
            @MoveLetter.performed += instance.OnMoveLetter;
            @MoveLetter.canceled += instance.OnMoveLetter;
        }

        private void UnregisterCallbacks(IInputActions instance)
        {
            @Pan.started -= instance.OnPan;
            @Pan.performed -= instance.OnPan;
            @Pan.canceled -= instance.OnPan;
            @PickupLetter.started -= instance.OnPickupLetter;
            @PickupLetter.performed -= instance.OnPickupLetter;
            @PickupLetter.canceled -= instance.OnPickupLetter;
            @MoveLetter.started -= instance.OnMoveLetter;
            @MoveLetter.performed -= instance.OnMoveLetter;
            @MoveLetter.canceled -= instance.OnMoveLetter;
        }

        public void RemoveCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputActions instance)
        {
            foreach (var item in m_Wrapper.m_InputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputActions @Input => new InputActions(this);
    public interface IInputActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnPickupLetter(InputAction.CallbackContext context);
        void OnMoveLetter(InputAction.CallbackContext context);
    }
}