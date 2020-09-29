using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreB : MonoBehaviour
{
    CharacterElf characterelf;
    GameObject go;
    public Text txt1;
    public Text txt4;
    public int s;
    bool isAnim = false;
    bool isCounted = true;
    GameObject playerk;
    BallMaster ballmaster;

    void Start()
    {
        characterelf = FindObjectOfType<CharacterElf>();
        ballmaster = FindObjectOfType<BallMaster>();
        Debug.Log("00");
        txt1 = GameObject.Find("Text3").GetComponent<Text>();
        txt4 = GameObject.Find("Text4").GetComponent<Text>();
        playerk = GameObject.Find("PlayerControl");
    }

    private void Update()
    {
        if (isAnim)
        {
            AnimatorStateInfo info = txt1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (info.normalizedTime >= 0.99f&& isCounted)
            {
                StartCoroutine(Countdown());
                isCounted = false;
                playerk.GetComponent<controlBallMove>().enabled=false;
            }
        }
        if (Input.GetKey(KeyCode.Space)&& isAnim)
        {
            SceneManager.LoadScene("PhysicsGame");
        }
        
    }


    IEnumerator Countdown()
    {
        for (int i = 0; i < ballmaster.Sn + 1; i++)
        {
            txt1.text = i + "分";
            yield return new WaitForSeconds(0.5f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        go = FindUpParent(collision.gameObject.transform).gameObject;
        

        if (!go.GetComponent<CharacterElf>().isSnapped)
        {
            
            txt1.text = s +"分";

            txt1.GetComponent<Animator>().enabled= true;
            txt4.GetComponent<Animator>().enabled = true;
            isAnim = true;

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
