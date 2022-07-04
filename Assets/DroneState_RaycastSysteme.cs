using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneState_RaycastSysteme : DroneState_V02
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
    
    public void _listRaycastVectorSyteme(){
        
        for (int i = 0; i < _ListRaycastHit.Count; i++)
        {
            RaycastHit _hit;
            for (int y = 0; y < _listVector3.Count; y++)
            {
                if(Physics.Raycast(transform.position,_listVector3[y], out _hit, 20)){
                    if(_hit.collider.CompareTag("Player")){
                        _player=_hit.collider.gameObject;
                        Debug.Log(_player.gameObject.name);
                        Debug.Log(_player.gameObject.tag);
                        systemRaySignalLaunch?.Invoke();
                    }
                }
            }
        }
    }
}
