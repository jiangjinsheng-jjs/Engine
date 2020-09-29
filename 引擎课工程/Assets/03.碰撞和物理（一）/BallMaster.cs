using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaster : MonoBehaviour
{
    List <GameObject> snappedList =new List<GameObject>();
    GameObject go;
    GameObject go2;
    CharacterElf characterelf;
    ScoreB scoreb;
    public int Sn = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterelf = FindObjectOfType<CharacterElf>();
        scoreb = FindObjectOfType<ScoreB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Sn = snappedList.Count;
            foreach (var item in snappedList)
            {
                Destroy(item.GetComponent<HingeJoint>());
                go2 = FindUpParent(item.transform).gameObject;
                go2.GetComponent<CharacterElf>().isSnapped = false;
                scoreb.s--;
                scoreb.txt1.text = scoreb.s + "分";
            }

        snappedList = new List<GameObject>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        go= FindUpParent(collision.gameObject.transform).gameObject;
        
        if (collision.gameObject.CompareTag("Body") && !go.GetComponent<CharacterElf>().isSnapped)
        {
            collision.gameObject.AddComponent<HingeJoint>();
            collision.gameObject.GetComponent<HingeJoint>().connectedBody = GetComponent<Rigidbody>();
            go.GetComponent<CharacterElf>().isSnapped = true;
            
            snappedList.Add(collision.gameObject);
            
            scoreb.s++;
            scoreb.txt1.text = scoreb.s + "分";
        }
    }

    Transform FindUpParent(Transform zi)
    {
        if (zi.parent == null)
            return zi;
        else
            return FindUpParent(zi.parent);
    }

}
