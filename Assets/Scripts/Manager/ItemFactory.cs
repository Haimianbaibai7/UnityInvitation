using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public GameObject Letter;
    public GameObject UnityBoy_B;
    public GameObject UnityBoy_R;

    public Transform[] SpawnPoints;


    public void CreateLetter()
    {
        Instantiate(Letter, SpawnPoints[0]);
    }

    public void CreateUnityBoy()
    {
        int a = Random.Range(0, 2);
        int position = Random.Range(0, 3);
        if (a==0)
        {
            Instantiate(UnityBoy_B, SpawnPoints[a].position,Quaternion.identity);
        }
        else
        {
            Instantiate(UnityBoy_R, SpawnPoints[a].position,Quaternion.identity);
        }

    }
}
