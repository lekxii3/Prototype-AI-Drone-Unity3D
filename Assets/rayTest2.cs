using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest2 : MonoBehaviour
{
    public delegate void systemRaySignal();
    public static systemRaySignal systemRaySignalLaunch;
    RaycastHit _rayCenter;
    RaycastHit _rayNegativePos1;
    RaycastHit _rayNegativePos2;
    RaycastHit _rayNegativePos3;
    RaycastHit _rayNegativePos4;
    RaycastHit _rayNegativePos5;
    RaycastHit _rayNegativePos6;
    RaycastHit _rayNegativePos7;
    RaycastHit _rayPositivePos1;
    RaycastHit _rayPositivePos2;
    RaycastHit _rayPositivePos3;
    RaycastHit _rayPositivePos4;
    RaycastHit _rayPositivePos5;
    RaycastHit _rayPositivePos6;
    RaycastHit _rayPositivePos7;
    public List<RaycastHit> _listHit= new List<RaycastHit>();
    float currentValue =-7;
    float incrementValue=1f; 
    List<Transform> _ListTransformDrone= new List<Transform>();
    Transform _playerPos;
    GameObject _player;
    
        
    private void Update() {       
        systemRayDetection();
    }

    private void OnEnable() {
        rayTest2.systemRaySignalLaunch+=_AddListPlayer;
    }
    private void OnDisable() {
        rayTest2.systemRaySignalLaunch-=_AddListPlayer;
    }

    void systemRayDetection(){
        if(Physics.Raycast(transform.position, new Vector3(0,0,20), out _rayCenter,20)){
            if(_rayCenter.collider.CompareTag("Player")){
                systemRaySignalLaunch?.Invoke();
            }
            Debug.DrawRay(transform.position, new Vector3(0,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-7,0,20), out _rayNegativePos1,20)){
            Debug.DrawRay(transform.position, new Vector3(-7,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-6,0,20), out _rayNegativePos2,20)){
            Debug.DrawRay(transform.position, new Vector3(-6,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-5,0,20), out _rayNegativePos3,20)){
            Debug.DrawRay(transform.position, new Vector3(-5,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-4,0,20), out _rayNegativePos4,20)){
            Debug.DrawRay(transform.position, new Vector3(-4,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-3,0,20), out _rayNegativePos5,20)){
            Debug.DrawRay(transform.position, new Vector3(-3,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-2,0,20), out _rayNegativePos6,20)){
            Debug.DrawRay(transform.position, new Vector3(-2,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(-1,0,20), out _rayNegativePos7,20)){
            Debug.DrawRay(transform.position, new Vector3(-1,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(7,0,20), out _rayPositivePos1,20)){
            Debug.DrawRay(transform.position, new Vector3(7,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(6,0,20), out _rayPositivePos2,20)){
            Debug.DrawRay(transform.position, new Vector3(6,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(5,0,20), out _rayPositivePos3,20)){
            Debug.DrawRay(transform.position, new Vector3(5,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(4,0,20), out _rayPositivePos4,20)){
            Debug.DrawRay(transform.position, new Vector3(4,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(3,0,20), out _rayPositivePos5,20)){
            Debug.DrawRay(transform.position, new Vector3(3,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(2,0,20), out _rayPositivePos6,20)){
            Debug.DrawRay(transform.position, new Vector3(2,0,20));            
        }
        if(Physics.Raycast(transform.position, new Vector3(1,0,20), out _rayPositivePos7,20)) {
            Debug.DrawRay(transform.position, new Vector3(1,0,20));            
        }
    }

    void _AddListPlayer(){
        //_player=GameObject.FindGameObjectWithTag("Player");
        _player=_rayCenter.collider.gameObject;
        Debug.Log(_player.gameObject.name);
        Debug.Log(_player.gameObject.tag);
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*private void Start() {
        _listHit.Add(_rayCenter);
        _listHit.Add(_rayNegativePos1);
        _listHit.Add(_rayNegativePos2);
        _listHit.Add(_rayNegativePos3);
        _listHit.Add(_rayNegativePos4);
        _listHit.Add(_rayNegativePos5);
        _listHit.Add(_rayNegativePos6);
        _listHit.Add(_rayNegativePos7);
        _listHit.Add(_rayPositivePos1);
        _listHit.Add(_rayPositivePos2);
        _listHit.Add(_rayPositivePos3);
        _listHit.Add(_rayPositivePos4);
        _listHit.Add(_rayPositivePos5);
        _listHit.Add(_rayPositivePos6);
        _listHit.Add(_rayPositivePos7);
    }

    private void Update() {
        foreach (RaycastHit _hit in _listHit)
        {
            PosRay();
            if(currentValue==6f){
                currentValue=-6f;
            }
        }

        for (int i = 0; i < _listHit.Count; i++)
        {
            PosRay();
        }
    }
    
   public void PosRay(in List<RaycastHit> _listHit){
    RaycastHit _rayHit;
    Vector3 _direction= new Vector3(currentValue,0,20);
    Physics.Raycast(transform.position, _direction,out _rayHit);
   }*/
}
