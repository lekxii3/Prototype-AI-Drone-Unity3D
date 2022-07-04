using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionGround : MonoBehaviour
{
    public Transform playerPos;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            
        }
    }
}
