using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHeadset : MonoBehaviour
{
    [SerializeField] private GameObject vrHeadset;

    private void Update()
    {
        gameObject.transform.position = vrHeadset.transform.position;
    }
}
