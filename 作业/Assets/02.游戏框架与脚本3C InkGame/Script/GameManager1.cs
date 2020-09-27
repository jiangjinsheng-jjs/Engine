using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject dieCanvas;
    GameObject character;
    BackTime backtime;

    // Start is called before the first frame update
    void Start()
    {
        
        character = GameObject.Find("角色");
        backtime=FindObjectOfType<BackTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.y < 1)
        {
            dieCanvas.SetActive(true);
            character.GetComponent<MoveController>().enabled = false;
            Score.txt2.text = "分";
            Score.txt2.color = new Vector4(0.0f, 0.0f, 0.0f,1.0f);
            backtime.DeleteBigInk();
            backtime.DeleteScene();
            backtime.CreatScene();
            Time.timeScale = 0;
            
        }
    }
}
