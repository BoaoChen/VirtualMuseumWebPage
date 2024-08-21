using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.UI;
using UnityEngine.Video;

public class OpenVideo : MonoBehaviour
{
    public VRInteractiveItem itemVR;
    public GameObject VideoPanel;

    void Awake()
    {
        itemVR = GetComponent<VRInteractiveItem>();
    }
    void OnEnable()
    {
        itemVR.OnReady +=openVideo;
    }
    public void openVideo()
    {
         VideoPanel.SetActive(true);
        MusicCtrl.instance.pauseMusic();
        //锁定指针到视图中心
        Cursor.lockState = CursorLockMode.None;
        //隐藏指针
        Cursor.visible = true;
    }
}
