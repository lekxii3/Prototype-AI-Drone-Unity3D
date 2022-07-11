using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest3 : MonoBehaviour
{
    public delegate void systemRaySignal();
    public static systemRaySignal systemRaySignalLaunch;
    Transform _playerPos;
    GameObject _player;
    List<Vector3> _listVector3;
    List<RaycastHit> _ListRaycastHit;

    private void Start() {        

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
    
    private void Update() {       
        _listRaycastVectorSyteme();
    }

    void _listRaycastVectorSyteme(){
        for (int i = 0; i < _ListRaycastHit.Count; i++)
        {
           
            for (int y = 0; y < _listVector3.Count; y++)
            {
                RaycastHit _hit;
                if(Physics.Raycast(transform.position,_listVector3[y], out _hit, 20)){
                    Debug.DrawRay(transform.position,_listVector3[y],Color.white);
                    if(_hit.collider.CompareTag("Player")){
                        _player = _hit.collider.gameObject;
                    }
                }
            }
        }
    }
        
    
    

    
    void _AddListPlayer(){        
        
        Debug.Log(_player.gameObject.name);
        Debug.Log(_player.gameObject.tag);
    }
}
