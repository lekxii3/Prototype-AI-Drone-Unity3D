using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class GunBehaviour : Viewfinder
{
    Rigidbody _rb;
    public Transform SpawnBullet;
    public GameObject Bullet;
    float _powerImpulseBullet= 10000f;
    bool _isPressed;

    private void Update() {
        if(_isPressed==true){
            _instantiateBulletPrefab();
        }
    }

    private void OnEnable() {
        TriggerPressedForFire.FireSignalPositiveBool +=_FireBoolTrue;
        TriggerPressedForFire.FireSignalNegativeBool +=_FireBoolFalse;
    }
    private void OnDisable() {
        TriggerPressedForFire.FireSignalPositiveBool -=_FireBoolTrue;
        TriggerPressedForFire.FireSignalNegativeBool -=_FireBoolFalse;
    }

    void _instantiateBulletPrefab(){
        SpawnBullet.LookAt(RayPos());        
        GameObject _newBullet = Instantiate(Bullet,SpawnBullet.transform.position,Quaternion.identity);
        _newBullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.forward*_powerImpulseBullet);
    }

    void _FireBoolTrue(){
        _isPressed=true;
    }
    void _FireBoolFalse(){
        _isPressed=false;
    }
}
