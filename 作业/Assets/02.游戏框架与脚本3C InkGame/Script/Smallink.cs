using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smallink : MonoBehaviour
{
    

    GameObject[] smallinkPrefab;
    int RandRotate;

    void Start()
    {
        smallinkPrefab = GameObject.FindGameObjectsWithTag("Smallink");
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RandRotate = Random.Range(0, 360);
            Instantiate(smallinkPrefab[Random.Range(0, 3)], transform.position, Quaternion.Euler(0, RandRotate, 0));
        }
    }
}
