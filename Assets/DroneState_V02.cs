using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneState_V02 : MonoBehaviour
{
    //if detection=true == state shig and shot 
    NavMeshAgent _navMesh;  
    private Rigidbody _rb;  
    DroneState_RaycastSysteme _droneState_RaycastSyteme;

    [Header ("State Machine")]
    public DroneStatement state = DroneStatement.None;
    public DroneStatement nexState = DroneStatement.None;  

    [Header("Patrol")] 
    public bool destinationA = false;
    public bool destinationB = false;
    public Transform positionA;
    public Transform positionB;
    
    [Header("Detection")]
    public bool detected = false;
    

    [Header("Damage")] 
    private bool damage = false;

    public enum DroneStatement
    {
        None,
        Patrol,
        Alert,
        Shooting,
        RunAway,
        Damage,
    }
    
    private void Start() {
        _navMesh = gameObject.GetComponent<NavMeshAgent>();
        _rb = gameObject.GetComponent<Rigidbody>();
        destinationA = true;
        state = DroneStatement.Patrol;
        nexState = DroneStatement.Patrol;
    }
    
    private void Update() 
{
    if(CheckForTransition())
    {
        TransitionState();
    }
    StateBehavior();
}

    private bool CheckForTransition() // porte qui s'ouvre pour démarré la transition vers un autre etat
{
    switch(state)
    {
        case DroneStatement.None:
            break;
        //---------------------------------------------------------------------//
        case DroneStatement.Patrol:
        
        if(detected == true)
        {
            nexState = DroneStatement.Shooting;
            return true;
        }
        if (damage == true)
        {
            nexState = DroneStatement.Damage;
        }
        break;
        //---------------------------------------------------------------------//
        case DroneStatement.Alert:
      
        if(detected == true)
        {
            nexState = DroneStatement.Shooting;
            return true;
        }          
        if(detected == false)
        {
            nexState = DroneStatement.Patrol;
            return true;
        }
        if (damage == true)
        {
            nexState = DroneStatement.Damage;
        }
        break;
        //---------------------------------------------------------------------//
        case DroneStatement.Shooting:
        
        if(detected == false)
        {
            nexState = DroneStatement.Patrol;
            return true;
        }
        if (damage == true)
        {
            nexState = DroneStatement.Damage;
        }
        break;
        //---------------------------------------------------------------------//
        case DroneStatement.RunAway:
        
        break;
        //---------------------------------------------------------------------//
        case DroneStatement.Damage:
        if (damage == false)
        {
            nexState = DroneStatement.Shooting;
        }
        break;
    }
    return false;
}


    private void TransitionState() // effectue le chemin de la transition, d'un etat a un autre 
{
    switch(nexState)
    {
        case DroneStatement.None:
        // etat vide, transite automatiquement vers Patrol
        break;

        case DroneStatement.Patrol:
        // etat de patrouille d'un point A vers B 
        break;

        case DroneStatement.Alert:
        //etat de contact, tres courte etat qui transite rapidement entre Shooting ou Patrol
        break;

        case DroneStatement.Shooting:
        //etat d'attaque vers le player
        break;

        case DroneStatement.RunAway:
        //etat de fuite si HP 1 
        break;
        
        case DroneStatement.Damage:
            
        break;
    }

    state = nexState;
}

    private void StateBehavior()  //realisation de l'etat
    {
        switch(state)
        {
            case DroneStatement.None:            
            // etat vide, transite automatiquement vers Patrol
            break;

            case DroneStatement.Patrol:
            PatrolState();
            _droneState_RaycastSyteme._listRaycastVectorSyteme();
            //etat de patrouille d'un point A vers B
            break;

            case DroneStatement.Alert:
            //etat de contact, tres courte etat qui transite rapidement entre Shooting ou Patrol                              
            break;

            case DroneStatement.Shooting:
            //etat d'attaque vers le player
            break;

            case DroneStatement.RunAway:
            //etat de fuite si HP 1 
            break;
            
            case DroneStatement.Damage:
            break;
        }
    }

private void PatrolState()

{
    _navMesh.stoppingDistance = 0.0f;          
    if(destinationA == true && _navMesh.remainingDistance<2f)
    {
        destinationA = false;
        destinationB = true;
        _navMesh.SetDestination(positionB.position);
    }
    else if(destinationB == true && _navMesh.remainingDistance<2f)
    {
        destinationB = false;
        destinationA = true;
        _navMesh.SetDestination(positionA.position);
    }        
}


}
