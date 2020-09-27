using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPtest : MonoBehaviour
{

    float timer;
    bool isinjured;
    StoneOccur stoneoccur;
    

    void Start()
    {
        timer = 0.0f;
        isinjured = false;
        stoneoccur = FindObjectOfType<StoneOccur>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            Destroy(GetComponent<Rigidbody>());
            isinjured = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("StoneTest") && !isinjured)
        {
            isinjured = true;
            Debug.Log("aa");
            
            Score.y-=0.5f;
            Score.x -= 1;
            Score.txt1.text = Score.x + "";
            Score.txt2.text = Score.y + "";

            GameObject myfather = gameObject.transform.parent.gameObject;
            if (stoneoccur.StoneList.Contains(myfather))
            {
                stoneoccur.StoneList.Remove(myfather);
            }
            myfather.SetActive(false);
        }
    }
}
