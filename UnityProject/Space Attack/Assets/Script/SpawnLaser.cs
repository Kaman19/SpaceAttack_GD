using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{

    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnLaserD()
	{
        GameObject la = Instantiate(laser);
        la.transform.SetParent(transform, false);
        Quaternion rottation = Quaternion.Euler(0, 0, 270);
        la.transform.rotation = rottation;
    }
}
