using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTime : MonoBehaviour
{
    // Start is called before the first frame update

    StoneOccur stoneOccur;
    
    public GameObject[] InkListPress;
    public GameObject[] InkListScene;
    bool[] stonehascoll;
    Vector3[] rotateAngle;
    Vector3[] stoneDir;
    Vector3[] stonePos;
    int[] typeArray;
    int goodLength=0;
    int deleteLength = 0;

    void Start()
    {
        stoneOccur = GetComponent<StoneOccur>();    
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            InkListScene = GameObject.FindGameObjectsWithTag("Bigink");//点K后收集大墨
            DeleteScene();
            DeleteBigInk();
            CreatScene();
        }
        if (Input.GetKey(KeyCode.K))
        {
            Time.timeScale = 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            Time.timeScale = 1f;
        }

    }


    public void RecordScenes()
    {
        InkListPress = GameObject.FindGameObjectsWithTag("Bigink");//点J后收集大墨
        
        int length = stoneOccur.StoneList.Count;
        Debug.Log(length);
        stonehascoll = new bool[length];
        rotateAngle = new Vector3[length];
        stoneDir = new Vector3[length];
        stonePos = new Vector3[length];
        typeArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            stonehascoll[i] = stoneOccur.StoneList[i].GetComponent<StoneMaster>().hascollstop ;
            rotateAngle[i] = stoneOccur.StoneList[i].transform.rotation.eulerAngles;
            stoneDir[i] = stoneOccur.StoneList[i].GetComponent<StoneMaster>().movedir;
            stonePos[i] = stoneOccur.StoneList[i].transform.position;
            typeArray[i] = stoneOccur.StoneList[i].GetComponent<StoneMaster>().type;
        }
    }

    public void CreatScene()
    {
        stoneOccur.StoneList = new List<GameObject>();
        int length = stonehascoll.Length;

            for (int i = 0; i < length; i++)
            {
                
            GameObject go =Instantiate(stoneOccur.stonePrefab[typeArray[i]], stonePos[i], Quaternion.Euler(rotateAngle[i]));
            stoneOccur.StoneList.Add(go);
            go.GetComponent<StoneMaster>().type= typeArray[i];
            go.GetComponent<StoneMaster>().hascollstop = stonehascoll[i];
            go.GetComponent<StoneMaster>().movedir = stoneDir[i];
            go.transform.SetParent(stoneOccur.DadAll.transform);
            }
        
        
        
    }

    public void DeleteScene()
    {
        //删除所有石头
        for (int i = 0; i < stoneOccur.DadAll.transform.childCount; i++)
        {
            Destroy(stoneOccur.DadAll.transform.GetChild(i).gameObject);
        }

        
    }

    public void DeleteBigInk()
    {
        //删除无效大墨
        //Debug.Log(InkListScene.Length);

        for (int i = InkListPress.Length; i < InkListScene.Length; i++)
        {

            Destroy(InkListScene[i]);
        }
    }
}
