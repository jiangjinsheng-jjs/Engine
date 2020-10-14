using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneOccur : MonoBehaviour
{
    public GameObject[] stonePrefab;
    Vector3 RandV3;
    GameObject go;
    Vector2 WH = new Vector2(15.0f,8.0f);
    float timer=0;
    int k;
    public List<GameObject> StoneList;
    public GameObject DadAll;

    void Start()
    {
        Invoke("CreateStone",1.0f);
        stonePrefab = GameObject.FindGameObjectsWithTag("Stone");
    }

    

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    void CreateStone()
    {
        float Randx = Random.Range(-9.0f, 9.0f);
        float Randy = Random.Range(-5.0f, 5.0f);
        int RandRotate = Random.Range(0, 100)*90;
        int RandID = Random.Range(0, 4);

        k = Random.Range(1,5);
        switch (k)
        {
            case 1:
                RandV3 = new Vector3(Randx, 0, WH.y);
                go = Instantiate(stonePrefab[RandID], RandV3,Quaternion.Euler(0,RandRotate,0));
                go.transform.SetParent(DadAll.transform);
                go.GetComponent<StoneMaster>().type = RandID;
                go.GetComponent<StoneMaster>().movedir = Vector3.back;
                StoneList.Add(go);
                break;
            case 2:
                RandV3 = new Vector3(Randx, 0, -WH.y);
                go = Instantiate(stonePrefab[RandID], RandV3, Quaternion.Euler(0, RandRotate, 0));
                go.transform.SetParent(DadAll.transform);
                go.GetComponent<StoneMaster>().type = RandID;
                go.GetComponent<StoneMaster>().movedir = Vector3.forward;
                StoneList.Add(go);
                break;
            case 3:
                RandV3 = new Vector3(-WH.x, 0, Randy);
                go = Instantiate(stonePrefab[RandID], RandV3, Quaternion.Euler(0, RandRotate, 0));
                go.transform.SetParent(DadAll.transform);
                go.GetComponent<StoneMaster>().type = RandID;
                go.GetComponent<StoneMaster>().movedir = Vector3.right;
                StoneList.Add(go);
                break;
            case 4:
                RandV3 = new Vector3(WH.x, 0, Randy);
                go = Instantiate(stonePrefab[RandID], RandV3, Quaternion.Euler(0, RandRotate, 0));
                go.transform.SetParent(DadAll.transform);
                go.GetComponent<StoneMaster>().type = RandID;
                go.GetComponent<StoneMaster>().movedir = Vector3.left;
                StoneList.Add(go);
                break;
                //以上下左右为顺序
        }

        Invoke("CreateStone", Random.Range(0.4f-timer/120, 2.0f-timer/80));
    }
}    
