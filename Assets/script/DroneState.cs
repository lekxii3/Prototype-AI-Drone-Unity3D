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
    public bool destinationA = false;
    public bool destinationB = false;
    public Transform positionA;
    public Transform positionB;

    [Header("Detection")]
    public Transform playerPosition;
    public GameObject player;
    public Transform dronePosition;
    public float detectionDistance = 1f;
    public LayerMask playerLayer;
    public bool detected = false;

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

private void Start() 
{
    _navMesh = gameObject.GetComponent<NavMeshAgent>();
    destinationA = true;
    state = DroneStatement.Patrol;

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
        // etat vide, transite automatiquement vers Patrol
        break;

        case DroneStatement.Patrol:
        // etat de patrouille d'un point A vers B 
        if(detected == true)
        {
            nexState = DroneStatement.Alert;
            return true;
        }
        
        break;

        case DroneStatement.Alert:
        //etat de contact, tres courte etat qui transite rapidement entre Shooting ou Patrol
        if(detected == false)
        {
            nexState = DroneStatement.Patrol;
            return true;
        }
        if(detected == true)
        {
            nexState = DroneStatement.Shooting;
            return true;
        }
        break;

        case DroneStatement.Shooting:
        //etat d'attaque vers le player
        if(detected == false && nexState != DroneStatement.Alert){
            nexState = DroneStatement.Patrol;
            return true;
        }
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
            Debug.Log("none");
            // etat vide, transite automatiquement vers Patrol

            break;

            case DroneStatement.Patrol:
            Debug.Log("patrol");
            //etat de patrouille d'un point A vers B 
            PatrolState();
            DetectionState();
            break;

            case DroneStatement.Alert:
            Debug.Log("Alert");
            //etat de contact, tres courte etat qui transite rapidement entre Shooting ou Patrol
                              
            break;

            case DroneStatement.Shooting:
            Debug.Log("shooting");
            //etat d'attaque vers le player
            if(detected == true)
            {
                Debug.Log("je te tire dessus");
            }

            break;

            case DroneStatement.RunAway:
            Debug.Log("runaway");

            //etat de fuite si HP 1 

            break;

        }
    }

    private void DetectionState()
    {
        if(player.gameObject != null)
        {
            direction = Vector3.Normalize(player.transform.position - dronePosition.position);

            if(Physics.Raycast(dronePosition.position, direction, out _raycastHit, 12f))
            {
                if(_raycastHit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("je te vois");
                    detected = true;
                    Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.green, 1f );
                }
                else{
                    detected = false;
                }
                                               
            } 
            else{
                detected = false;
            }                     
        }        
                
    }


    private void PatrolState()
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


}
 