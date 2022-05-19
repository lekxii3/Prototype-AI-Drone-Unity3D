using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private bool delay = true;
    [SerializeField] private Transform camera;
    [SerializeField] private GameObject bulletPrefab;
    public float bulletspeed = 10000f;
    


    private void Update()
    {
        RaycastPlayerCamera();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,0,1*moveSpeed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,0,-1*moveSpeed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-1*rotateSpeed*Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,1*rotateSpeed*Time.deltaTime,0));
        }
        
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(InstantiateBullet());
        }
    }


    private void RaycastPlayerCamera()
    {
        Debug.DrawRay(camera.position, camera.forward, Color.green);
    }


    private IEnumerator InstantiateBullet()
    {
        
            GameObject Newbullet = Instantiate(bulletPrefab, camera.transform.position, camera.transform.rotation);
            Newbullet.GetComponent<Rigidbody>().AddForce(camera.forward * bulletspeed);
            yield return new WaitForSeconds(0.5f);
    }
    
}
