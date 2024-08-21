using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;
public class GameObjectManager : MonoBehaviour
{
    private PlayerInputHandle inputHandle;
    public VRInteractiveItem itemVR;
    public GameObject GO;
    void Awake()
    {
        itemVR = GetComponent<VRInteractiveItem>();
        inputHandle = FindObjectOfType<PlayerInputHandle>();
    }
    void OnEnable()
    {
        itemVR.OnReady += GOClick;
    }
    public void GOClick()
    {
        GO.SetActive(true);
        MusicCtrl.instance.pauseMusic();
        //锁定指针到视图中心
        Cursor.lockState = CursorLockMode.None;
        //隐藏指针
        Cursor.visible = true;
        //固定视角
        inputHandle.lookSensitivity = 0;
    }
}