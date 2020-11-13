using UnityEngine;
using System.Collections;
using UnityEngine.UI;               

public class Score : MonoBehaviour
{
	public static Text txt1;
	public static Text txt2;//定义静态变量名以用于其他脚本内的引用**
	public static Text txt3;
	public static float x = 0;
	public static float y = 3;
	float timer = 120;
	float min;
	int sec;


	void Start()
	{
		txt1 = GameObject.Find("Text").GetComponent<Text>();
		txt2 = GameObject.Find("Text2").GetComponent<Text>();
		txt3 = GameObject.Find("Text3").GetComponent<Text>();
	}

    void Update()
    {
		timer = timer - Time.deltaTime;

		sec = ((int)timer) % 60;
		min = Mathf.Floor((timer - (float)sec)/60);
		txt3.text = min + ": "+sec; 

	}


}