using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class TwoGun : Viewfinder
{
    Rigidbody _rb;
    public Transform SpawnBullet;
    public GameObject Bullet;
    float _powerImpulseBullet= 10000f;

    private void OnEnable() {
        Fire.FireSignalLaunch +=_instantiateBulletPrefab;
    }
    private void OnDisable() {
        Fire.FireSignalLaunch -=_instantiateBulletPrefab;
    }

    void _instantiateBulletPrefab(){        
        GameObject _newBullet = Instantiate(Bullet,SpawnBullet.transform.position,Quaternion.identity);
        _newBullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.forward*_powerImpulseBullet);
    }
}
