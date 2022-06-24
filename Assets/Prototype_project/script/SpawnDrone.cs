using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrone : MonoBehaviour
{   
    public GameObject drone;
    private int numberDroneToInstantiate=5;

    private int indexLimit=0;
    public List<GameObject> ennemyGroupe = new List<GameObject>();

   
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SpawnEnnemyGroup();
        }    
    }

    private void SpawnEnnemyGroup()
    {
        if(indexLimit ==0)
        {
            for (int i = 0; i < numberDroneToInstantiate; i++)
            {
                ennemyGroupe.Add((GameObject)Instantiate(drone,transform.position,Quaternion.identity));
            }
            indexLimit++;
        }

    }
}
