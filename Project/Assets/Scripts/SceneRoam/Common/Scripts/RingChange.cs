using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using VRStandardAssets.Utils;

public class RingChange : MonoBehaviour {
    Image thisImage;
    VREyeRaycaster itemVr;

    public float timeTemp=0f;
    public float timeTotal = 2f;
    public bool isReady = false;
	// Use this for initialization
	void Start () {
		thisImage=gameObject.GetComponent<Image>();
        itemVr = Camera.main.GetComponent<VREyeRaycaster>();//Camera.main代表主摄像机
	}
	// Update is called once per frame
	void Update () {
        //准心的图片填充
        float amount = 0f;
		if(itemVr.CurrentInteractible)//判断是否有可交互物体
        {
            timeTemp += Time.deltaTime;
             amount= timeTemp / timeTotal;

            if(timeTemp>timeTotal)//准心图片加载时间大于预期时间，加载好了
            {
               if(!isReady)
               {
                   isReady = true;
                   Debug.Log("Ready!");
                   itemVr.CurrentInteractible.Ready();
               }
            }
        }
        else//离开可交互物体
        {
            timeTemp = 0;
            amount = 0;
            isReady = false;//关掉
        }

        thisImage.fillAmount = amount;
	}
}
