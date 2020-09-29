using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : MonoBehaviour
{

    public float speed = 0.02f;
    float timer = 1.0f;
    float x;
    float y;
    public BackTime backtime;

    void Awake()
    {
       
    }

    
        
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J))
        {
            timer = 0.0f;
            speed = 0.2f;
            
            backtime.RecordScenes();
            
        }

        if (timer >= 0.08f)
        {
            speed = 0.02f;
        }

        


        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x*speed,0, y * speed), Space.World);
    }
}

