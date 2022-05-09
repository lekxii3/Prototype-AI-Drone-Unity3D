using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneState : MonoBehaviour
{
    public NavMeshAgent _navMesh;
    


    [Header ("State Machine")]
    public DroneStatement state = DroneStatement.None;
    public DroneStatement nexState = DroneStatement.None;

    [Header ("Patrol")]
    public bool destinationA = true;
    public bool destinationB = false;
    public Transform positionA;
    public Transform positionB;

    [Header("Detection")]
    public Transform playerPosition;
    public GameObject player;
    public Transform dronePosition;
    public float detectionDistance = 1f;
    public LayerMask playerLayer;

    [Header ("Raycast")]
    private RaycastHit _raycastHit;
    private Vector3 direction;



    public enum DroneStatement
    {
        None,
        Patrol,
        Alert,
        Shooting,
        RunAway,
    }


private void Update() 
{   
    
    TestBehavior();
    Detection();
}

private void TestBehavior()
{
    if(destinationA == true && _navMesh.remainingDistance<0.5f)
            {
                destinationA = false;
                
                _navMesh.SetDestination(positionB.position);
            }
            else if(_navMesh.remainingDistance<0.5f)
            {
                destinationA = true;
                _navMesh.SetDestination(positionA.position);
            }
}


private bool CheckForTransition() // porte qui s'ouvre pour démarré la transition vers un autre etat
{
    switch(state)
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

            //etat de patrouille d'un point A vers B 
             if(destinationA == true && _navMesh.remainingDistance<0.5f)
            {
                destinationA = false;
                
                _navMesh.SetDestination(positionB.position);
            }
            else if(_navMesh.remainingDistance<0.5f)
            {
                destinationA = true;
                _navMesh.SetDestination(positionA.position);
            }

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

        }
    }

    private void Detection()
    {
        if(player.gameObject != null)
        {
            direction = Vector3.Normalize(player.transform.position - dronePosition.position);

            if(Physics.Raycast(dronePosition.position, direction, out _raycastHit, 12f, playerLayer))
            {
                print("je te vois");
                Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.green, 1f );
                
            }
            else
            {
                Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.red, 1f );
            }

            

        
        }

        
    }

}
 