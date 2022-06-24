using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 rotation;

    void FixedUpdate()
    {
        //fais tourner le cube en continue
        rotation.y = 50f * Time.deltaTime;
        this.gameObject.transform.Rotate(rotation);
    }
}
