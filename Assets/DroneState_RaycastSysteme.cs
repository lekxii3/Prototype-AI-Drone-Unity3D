using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneState_RaycastSysteme : MonoBehaviour
{
    public delegate void systemRaySignal();
    public static systemRaySignal systemRaySignalLaunch;
    Transform _playerPos;
    public GameObject _player;
    public List<Vector3> _listVector3;
    public List<RaycastHit> _ListRaycastHit;

    protected virtual void _listRaycastVectorSyteme(){
        
        for (int i = 0; i < _ListRaycastHit.Count; i++)
        {
            for (int y = 0; y < _listVector3.Count; y++)
            {   
                RaycastHit _hit;
                if(Physics.Raycast(transform.position,transform.TransformDirection(_listVector3[y]), out _hit, 20)){
                    if(_hit.collider.CompareTag("Player")){
                        Debug.DrawRay(transform.position,transform.TransformDirection(_listVector3[y]));
                        GetComponent<DroneState_V02>().detected=true; //------
                        Debug.Log(GetComponent<DroneState_V02>().detected);
                        _player=_hit.collider.gameObject;
                        Debug.Log(_player.gameObject.name);
                        Debug.Log(_player.gameObject.tag);                        
                    }else{
                    GetComponent<DroneState_V02>().detected=false;
                    Debug.Log(GetComponent<DroneState_V02>().detected);
                }
                }else{
                    GetComponent<DroneState_V02>().detected=false;
                    Debug.Log(GetComponent<DroneState_V02>().detected);
                }
            }
        }
    }

    protected virtual void Element_Start(){
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

    
}
