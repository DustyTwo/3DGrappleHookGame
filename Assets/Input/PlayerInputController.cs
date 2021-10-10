// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""Grounded"",
            ""id"": ""a8e2de78-517d-4650-9cbd-a41c84520459"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""3bf39392-a4fb-4ab5-9fbc-5a24e0e311ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Strafe"",
                    ""type"": ""Button"",
                    ""id"": ""77acf062-b07e-43ad-9c15-391c3ff08caf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b5a7d68a-49ea-4102-9193-dda8b9f0755a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""af3fc54e-3c6a-4f79-8800-da1438340b7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""fe1dd738-26e2-45c4-98f2-7628449e26ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Forward"",
                    ""id"": ""993c8891-54ac-4584-9c28-aa9058d93c00"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1d85a6e3-d0ca-46b6-b4ad-791be51cb572"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d2b49b81-71a6-4e0c-a41e-63d35490f04f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Strafe"",
                    ""id"": ""a982a406-d716-49b5-bfaa-9c63a28311db"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3e9bbce5-ced6-4301-9bc2-39a1c076860d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f59922a-f39a-4f2d-8154-524a3efecacc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a83fdb87-7ec4-45f6-ac6c-a76c592fe1d7"",
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
                    ""id"": ""266ae79a-fb40-4f73-887e-a0831d769919"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f0bd80a-9e80-4fe4-bfe5-26bb5b518729"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Grounded
        m_Grounded = asset.FindActionMap("Grounded", throwIfNotFound: true);
        m_Grounded_Run = m_Grounded.FindAction("Run", throwIfNotFound: true);
        m_Grounded_Strafe = m_Grounded.FindAction("Strafe", throwIfNotFound: true);
        m_Grounded_Jump = m_Grounded.FindAction("Jump", throwIfNotFound: true);
        m_Grounded_MouseDelta = m_Grounded.FindAction("MouseDelta", throwIfNotFound: true);
        m_Grounded_Grapple = m_Grounded.FindAction("Grapple", throwIfNotFound: true);
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

    // Grounded
    private readonly InputActionMap m_Grounded;
    private IGroundedActions m_GroundedActionsCallbackInterface;
    private readonly InputAction m_Grounded_Run;
    private readonly InputAction m_Grounded_Strafe;
    private readonly InputAction m_Grounded_Jump;
    private readonly InputAction m_Grounded_MouseDelta;
    private readonly InputAction m_Grounded_Grapple;
    public struct GroundedActions
    {
        private @PlayerInputController m_Wrapper;
        public GroundedActions(@PlayerInputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Grounded_Run;
        public InputAction @Strafe => m_Wrapper.m_Grounded_Strafe;
        public InputAction @Jump => m_Wrapper.m_Grounded_Jump;
        public InputAction @MouseDelta => m_Wrapper.m_Grounded_MouseDelta;
        public InputAction @Grapple => m_Wrapper.m_Grounded_Grapple;
        public InputActionMap Get() { return m_Wrapper.m_Grounded; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundedActions set) { return set.Get(); }
        public void SetCallbacks(IGroundedActions instance)
        {
            if (m_Wrapper.m_GroundedActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnRun;
                @Strafe.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnStrafe;
                @Strafe.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnStrafe;
                @Strafe.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnStrafe;
                @Jump.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @MouseDelta.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMouseDelta;
                @Grapple.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnGrapple;
            }
            m_Wrapper.m_GroundedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Strafe.started += instance.OnStrafe;
                @Strafe.performed += instance.OnStrafe;
                @Strafe.canceled += instance.OnStrafe;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
            }
        }
    }
    public GroundedActions @Grounded => new GroundedActions(this);
    public interface IGroundedActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnStrafe(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
    }
}
