using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneState : MonoBehaviour
{
    
    //a faire : etat follow ok, distance avec autre drone, et random entre different durée et nombre de tir. 
    
    
    public NavMeshAgent _navMesh;  
    private Rigidbody _rb;    

    [Header ("State Machine")]
    public DroneStatement state = DroneStatement.None;
    public DroneStatement nexState = DroneStatement.None;

    [Header("Patrol")] 
    public bool destinationA = false;
    public bool destinationB = false;
    public Transform positionA;
    public Transform positionB;
    //private bool resetPath = false;

    [Header("Detection")]
    public Transform playerPosition;    
    public GameObject player;
    public Transform dronePosition;
    public float detectionDistance = 1f;
    public LayerMask playerLayer;
    public bool detected = false;
    private Quaternion _lookrotation;

    [Header ("Raycast")]
    private RaycastHit _raycastHit;
    private Vector3 direction;

    [Header ("Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 10000f;    
    private bool _canShoot = true;

    [Header("Damage")] 
    private bool damage = false;
    public int health = 100;
    
    /* Event Manage */
    public delegate void SignalDroneAnim();
    public static event SignalDroneAnim SignalDroneAnimLaunch;
    

    public enum DroneStatement
    {
        None,
        Patrol,
        Alert,
        Shooting,
        RunAway,
        Damage,
    }

    
    
    private void Start() 
{
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
            //etat de patrouille d'un point A vers B 
            PatrolState();
            DetectionState();
            SurveillanceState();
            
            break;

            case DroneStatement.Alert:
            //etat de contact, tres courte etat qui transite rapidement entre Shooting ou Patrol                              
            break;

            case DroneStatement.Shooting:
                //etat d'attaque vers le player
            if(detected == true)
            {
                Target(); 
            }
                DetectionState();
                SurveillanceState();
                break;

            case DroneStatement.RunAway:
            //etat de fuite si HP 1 

            break;
            
            case DroneStatement.Damage:
                Damage();
                break;
        }
    }

    
    private void DetectionState()
    {
       Ray ray;
       RaycastHit hit;
       //Vector3 _directionTest = new Vector3.Normalize(dronePosition.transform.position-new Vector3(1,0,1));
       
       Debug.DrawRay(dronePosition.position, dronePosition.forward,Color.blue);
       Debug.DrawLine(dronePosition.position, Vector3.Normalize(dronePosition.transform.position-new Vector3(1,0,1)),Color.blue);
       Debug.DrawLine(dronePosition.position, Vector3.Normalize(dronePosition.transform.position-new Vector3(-1,0,1)),Color.blue);

    }

    //create 3 raycast en forward et if collide player so raycast sa position 

    void SurveillanceState()
    {
        if(player!= null)
        {
            direction = Vector3.Normalize(player.transform.position - dronePosition.position);

            
            Debug.Log(player.transform.position);
            
            if(Physics.Raycast(dronePosition.position, direction, out _raycastHit, 12f))
            {
                if(_raycastHit.collider.CompareTag("Player"))
                {
                    detected = true;
                    player.transform.position = player.transform.position;
                    Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.green, 1f);
                }
                else{
                    detected = false;                   
                }                                               
            } 
            else{
                detected = false;
            }                     
        }   
        Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.red, 1f);
    }

    private void Target()  
    {
        if(detected == true)
        {
            _navMesh.SetDestination(playerPosition.position);
            //resetPath = true;
            _navMesh.stoppingDistance = 8.0f;  
            Vector3 playerTargeted = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z);
            gameObject.transform.LookAt(playerTargeted);
            StartCoroutine(Shoot());
            //Debug.DrawRay(dronePosition.position, direction*_raycastHit.distance, Color.green, 1f );

        }

        /*else if(detected == false)
        {
            _navMesh.ResetPath();
            _navMesh.SetDestination(positionA.position);
        }*/
        
        
    }

    private void PatrolState()
{
    /*if (resetPath == true)
    {
        _navMesh.ResetPath();
        _navMesh.SetDestination(positionA.position);*/
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
       
       //_navMesh.SetDestination(positionA.position);

    /*}*/
        
        
}

    private void Cadence()
    {
        if(detected == true)
        {
            //GameObject NewBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            //NewBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletspeed);
        }
    }

    private IEnumerator Shoot()
    {
        if(_canShoot == true)
        {
            _canShoot = false;
            yield return new WaitForSeconds(0.5f);
            Cadence();
            _canShoot = true;
        }    
    }

    private void Damage()
    {
        health--;
        SignalDroneAnimLaunch?.Invoke();
        
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            damage = true;
            Damage();
            damage = false;
        }
    }

   
}
 