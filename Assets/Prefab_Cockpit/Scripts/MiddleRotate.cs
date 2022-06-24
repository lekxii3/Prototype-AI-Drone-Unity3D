using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRotate : MonoBehaviour
{
    private Vector3 rotation;

    void FixedUpdate()
    {
        //fais tourner le cube en continue
        rotation.z = 50f * Time.deltaTime;
        this.gameObject.transform.Rotate(rotation);
    }

}
