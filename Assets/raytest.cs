using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raytest : MonoBehaviour
{
    //Ray[] ray= new Ray[13];
    RaycastHit[] _hits= new RaycastHit[13];
    Vector3 _directionTest = new Vector3(1,0,1);
    float currentValue =-0.6f;
    float incrementValue=0.1f; 

    private void Start() {
       
    }
    void Update()
    {       
        foreach (RaycastHit _ray in _hits)
        {
            Debug.DrawRay(transform.position,transform.TransformDirection(new Vector3(currentValue,0,1)));
            _directionTest = transform.position - transform.TransformDirection(new Vector3(currentValue,0,1));
            Physics.Raycast(transform.position, _directionTest);
            //_hits = Physics.RaycastAll(transform.position, _directionTest,12f);
            currentValue = currentValue+incrementValue;
            //if(Physics.RaycastAll(out RaycastHit _hits))

            if(Physics.Raycast(transform.position,_directionTest, out RaycastHit _hits, 12f)){
                Debug.Log(_hits.collider.name);
            }
            if(currentValue==0.7f){
                currentValue=-0.6f;
            }

        }
    }






























            /*for (int i = 0; i < ray.Length-4; i++)
            {
                Debug.DrawRay(transform.position,transform.TransformDirection(new Vector3(currentValue,0,1)));
                currentValue = currentValue+incrementValue;
            }
            for (int i = 4; i < ray.Length; i++)
            {
                Debug.DrawRay(transform.position,transform.TransformDirection(new Vector3(currentValue,0,1)));
                currentValue = currentValue+incrementValueNegative;   
            }*/



    //Debug.DrawRay(transform.position, transform.forward,Color.blue);
    //Debug.DrawRay(transform.position, transform.TransformVector(new Vector3(1,0,1)),Color.blue);
    //Debug.DrawRay(transform.position, transform.TransformVector(new Vector3(-1,0,1)),Color.blue);
    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left),Color.blue);
}
