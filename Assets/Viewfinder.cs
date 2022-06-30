using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    public Transform headPosition;
    public Vector3 directionViewfinder;    
    Vector3 _resetPos= new Vector3(0,0,50f);
    private RaycastHit hit;
    public GameObject sphereViewfinder;

   private void Update() {    
    sphereViewfinder.transform.position = RayPos();
   }

  /*public void vector3Return(){
    if(Physics.Raycast(headPosition.transform.position , headPosition.transform.TransformVector(Vector3.forward), out hit, Mathf.Infinity)){
       if(hit.rigidbody != null){
            directionViewfinder = hit.point;
            sphereViewfinder.transform.position = hit.point;
       }
       else if(hit.rigidbody == null){
        hit.point = headPosition.transform.TransformVector(_resetPos);
       }
    }
   }*/
   
   public Vector3 RayPos()
   {
        if(Physics.Raycast(headPosition.transform.position , headPosition.transform.TransformVector(Vector3.forward), out hit, Mathf.Infinity) && hit.rigidbody !=null){
            return hit.point;
        } 
        else{
            hit.point = headPosition.transform.TransformVector(_resetPos);
        }
        return hit.point;
   }
   
}
