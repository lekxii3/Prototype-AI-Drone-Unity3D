using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimDroneManage : MonoBehaviour
{
    
    private int indexRandom = 0;
    public Animator AnimManage;

    private void Start()
    {
        AnimManage = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DroneState.SignalDroneAnimLaunch += AnimDamage;
    }

    private void OnDisable()
    {
        DroneState.SignalDroneAnimLaunch -= AnimDamage;
    }


    private void AnimDamage()
    {
       /* 
        indexRandom = Random.Range(1, 3);
        Debug.Log(indexRandom);
        AnimManage.SetInteger("AnimDamage", 2);
        indexRandom = 0;
        AnimManage.SetInteger("AnimDamage", 0);
        */
       Debug.Log("Je passe par là !!");
       AnimManage.SetTrigger("AnimDam");
    }
    
}
