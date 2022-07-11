using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollide : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
     if(other.gameObject.CompareTag("Player")){
            Debug.Log("touch");
        }
   }
}
