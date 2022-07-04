using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest3 : MonoBehaviour
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

    Dictionary<RaycastHit,Vector3> _dictionaryRaycastVector3;
    Dictionary<RaycastHit,Vector3[]> _dictionaryRaycastVector3Array;
    Dictionary<Physics,string> _dictionaryPhysicsString;

    List<Vector3> _listVector3;
    List<RaycastHit> _ListRaycastHit;

    private void Start() {
        _dictionaryRaycastVector3 = new Dictionary<RaycastHit, Vector3>(){
            {new RaycastHit(), new Vector3(0,0,20)},
            {new RaycastHit(), new Vector3(-7,0,20)},
            {new RaycastHit(), new Vector3(-6,0,20)},
            {new RaycastHit(), new Vector3(-5,0,20)},
            {new RaycastHit(), new Vector3(-4,0,20)},
            {new RaycastHit(), new Vector3(-3,0,20)},
            {new RaycastHit(), new Vector3(-2,0,20)},
            {new RaycastHit(), new Vector3(-1,0,20)},
            {new RaycastHit(), new Vector3(7,0,20)},
            {new RaycastHit(), new Vector3(6,0,20)},
            {new RaycastHit(), new Vector3(5,0,20)},
            {new RaycastHit(), new Vector3(4,0,20)},
            {new RaycastHit(), new Vector3(3,0,20)},
            {new RaycastHit(), new Vector3(2,0,20)},
            {new RaycastHit(), new Vector3(1,0,20)},
        };

        _dictionaryRaycastVector3Array=new Dictionary<RaycastHit, Vector3[]>(){
            {new RaycastHit(), new Vector3[]{new Vector3(0,0,20),new Vector3(-7,0,20), new Vector3(-6,0,20), new Vector3(-5,0,20), new Vector3(-4,0,20), new Vector3(-3,0,20), new Vector3(-2,0,20), new Vector3(-1,0,20), new Vector3(7,0,20), new Vector3(6,0,20), new Vector3(5,0,20), new Vector3(4,0,20), new Vector3(3,0,20), new Vector3(2,0,20), new Vector3(1,0,20)}}
        };

        _listVector3=new List<Vector3>(){
            {new Vector3(0,0,20)},
            {new Vector3(-7,0,20)},
            {new Vector3(-6,0,20)},
            {new Vector3(-5,0,20)},
            {new Vector3(-4,0,20)},
            {new Vector3(-3,0,20)},
            {new Vector3(-2,0,20)},
            {new Vector3(-1,0,20)},
            {new Vector3(7,0,20)},
            {new Vector3(6,0,20)},
            {new Vector3(5,0,20)},
            {new Vector3(4,0,20)},
            {new Vector3(3,0,20)},
            {new Vector3(2,0,20)},
            {new Vector3(1,0,20)}
        };

        _ListRaycastHit = new List<RaycastHit>(){
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()},
            {new RaycastHit()}
        };

        
    }

    void _listRaycastVectorSyteme(){
        for (int i = 0; i < _ListRaycastHit.Count; i++)
        {
            RaycastHit _hit;
            for (int y = 0; y < _listVector3.Count; y++)
            {
                if(Physics.Raycast(transform.position,_listVector3[y], out _hit, 20)){
                    if(_hit.collider.CompareTag("Player")){
                        systemRaySignalLaunch?.Invoke();
                    }
                }
            }
        }
    }

    void _dictionaryRaycastVectorSyteme(){
        foreach (KeyValuePair<RaycastHit,Vector3> kvp in _dictionaryRaycastVector3)
        {
            RaycastHit _hiit;
            //if(Physics.Raycast(transform.position,((byte)_dictionaryRaycastVector3.Values.Count)))  
        }

    }
    
        
    private void Update() {       
        _listRaycastVectorSyteme();
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
}
