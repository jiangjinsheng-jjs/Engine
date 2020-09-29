using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBallMove : MonoBehaviour
{

    public float speed = 0.1f;
    float timer = 1.0f;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x * speed, 0, y * speed), Space.World);
    }
}
