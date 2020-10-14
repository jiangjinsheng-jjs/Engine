using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMaster : MonoBehaviour
{
    // Start is called before the first frame update

    float Randspeed;
    GameObject[] biginkPrefab;
    int RandRotate ;
    public Vector3 RotateAngle;
    public bool hascollstop=false;//重置是否碰撞停下标志符
    
    public Vector3 movedir=Vector3.zero;
    
    public int type = 0;

    void Start()
    {
        if (hascollstop)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        Randspeed = Random.Range(0.5f, 1.0f);
        biginkPrefab = GameObject.FindGameObjectsWithTag("Bigink");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hascollstop)
        { 
            transform.Translate(movedir * Time.deltaTime * Randspeed,Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !hascollstop)
        {
            
            RandRotate = Random.Range(0, 5);

            Vector3 Collisionpoint = (transform.position + collision.transform.position) / Random.Range(1.8f, 2.2f);
            
            RotateAngle = new Vector3(0, RandRotate * 90,0);
            Instantiate(biginkPrefab[Random.Range(0, 4)], Collisionpoint, Quaternion.Euler(RotateAngle));


            transform.GetChild(0).gameObject.SetActive(true);
            hascollstop = true;

            Score.x++;
            Score.txt1.text = Score.x + "";
            Score.txt2.text = Score.y + "";

        }



    }


}
