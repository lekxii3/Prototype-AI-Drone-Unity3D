using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
public class TriggerPressedForFire : MonoBehaviour
{
    
    public delegate void FireSignal();
    public static FireSignal FireSignalPositiveBool;
    public static FireSignal FireSignalNegativeBool;
    [SerializeField] InputActionAsset PlayerController;
    InputAction _fire;
    bool _isPressed;
 

    void FixedUpdate() {
        triggerPressed();        
    }

    void triggerPressed(){
        var gameplayActionMap = PlayerController.FindActionMap("XRI RightHand Interaction");
        _fire = gameplayActionMap.FindAction("Activate");
        _fire.performed += FireTest; //here is once too much ... choice between performed=PressEntered or canceled=PressExited 
        _fire.canceled += NegativeBool;
        //_fire.triggered +=FireTest;
        _fire.Enable();       
    }

    void FireTest(InputAction.CallbackContext context){        
        FireSignalPositiveBool?.Invoke();       
    }
    void NegativeBool(InputAction.CallbackContext context){
        FireSignalNegativeBool?.Invoke();
    }
    
}
