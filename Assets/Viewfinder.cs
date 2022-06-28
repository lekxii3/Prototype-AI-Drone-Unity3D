using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    public Transform headPosition;
    public Vector3 directionViewfinder;    
    private RaycastHit hit;
    public GameObject sphereViewfinder;

   private void Update() {
    //Debug.DrawRay(headPosition.transform.position , headPosition.transform.TransformVector(Vector3.forward)*5, Color.red);
    
    sphereViewfinder.transform.position = RayPos();
   }

  public void vector3Return(){
    if(Physics.Raycast(headPosition.transform.position , headPosition.transform.TransformVector(Vector3.forward), out hit, Mathf.Infinity)){
       if(hit.rigidbody != null){
        directionViewfinder = hit.point;
        sphereViewfinder.transform.position = hit.point;
       }
    }
   }
   
   public Vector3 RayPos()
   {
        if(Physics.Raycast(headPosition.transform.position , headPosition.transform.TransformVector(Vector3.forward), out hit, Mathf.Infinity)){
            return hit.point;
        } 
        return hit.point;
   }
   
}
