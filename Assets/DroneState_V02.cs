using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneState_V02 : DroneState_RaycastSysteme
{
    //if detection=true == state shig and shot 
    NavMeshAgent _navMesh;  
    private Rigidbody _rb;  
        
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

    [Header ("Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 10000f;    
    private bool _canShoot = true;
    

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
        Element_Start();     
    }
    
    public void Update() 
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
            _listRaycastVectorSyteme();
            //etat de patrouille d'un point A vers B
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
            _listRaycastVectorSyteme();          
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

    
protected override void Element_Start() //ici nous allons initié ces elements, venant de l'heritage, dans la methode Start() de l'heritié 
{                                       //En utilisant Virtual et Override car il n'est pas possible que deux script de la meme famille fasse Start() chacun. 
    base.Element_Start();               //Et il fonctionne aussi bien lors d'un appel d'une methode de base : _listRaycastVectorSyteme() par exemple
}
private void Target()  
    {
        if(detected == true)
        {
            _navMesh.SetDestination(_player.transform.position);            
            _navMesh.stoppingDistance = 8.0f;  
            Vector3 playerTargeted = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            gameObject.transform.LookAt(playerTargeted);
            StartCoroutine(Shoot());
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
private void Cadence()
    {
        if(detected == true)
        {
            GameObject NewBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            NewBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletspeed);
        }
    }
}
