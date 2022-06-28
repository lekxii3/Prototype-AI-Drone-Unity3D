using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Fire : MonoBehaviour
{
    [SerializeField] InputActionAsset playerController;
    InputAction fire;

    private void Start() {
        var gameplayActionMap = playerController.FindActionMap("Default");

        fire = gameplayActionMap.FindAction("Trigger controller");

        fire.performed += FireTest;
        fire.canceled += FireTest;
        fire.Enable();
    }

    void FireTest(InputAction.CallbackContext context) 
    {
        Debug.Log("Fire !");
    }
}
