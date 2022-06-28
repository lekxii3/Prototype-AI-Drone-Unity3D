using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGun : Viewfinder
{
    public Transform SpawnBullet;
    public GameObject Gun;

    private void Start() {
       
    }
    
    void Update()
    {
        //Gun.transform.LookAt(RayPos());
        Gun.transform.LookAt(RayPos());
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,0f);
        transform.rotation = q;
        //Gun.GetComponentInChildren<Transform>().transform.LookAt(RayPos());
    }
}
