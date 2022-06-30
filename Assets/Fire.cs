using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
public class Fire : MonoBehaviour
{
    
    public delegate void FireSignal();
    public static FireSignal FireSignalLaunch;
    [SerializeField] InputActionAsset PlayerController;
    InputAction _fire;
 

    private void FixedUpdate() {
        triggerPressed();        
    }

    void triggerPressed(){
        var gameplayActionMap = PlayerController.FindActionMap("Default");
        _fire = gameplayActionMap.FindAction("Trigger controller");
        //_fire.performed += FireTest; //here is once too much ... choice between performed=PressEntered or canceled=PressExited 
        //_fire.canceled += FireTest;
        //_fire.triggered +=FireTest;
        _fire.Enable();
       
    }

    void FireTest(InputAction.CallbackContext context) 
    {
        Debug.Log("tire");
        FireSignalLaunch?.Invoke();
    }
    
}
