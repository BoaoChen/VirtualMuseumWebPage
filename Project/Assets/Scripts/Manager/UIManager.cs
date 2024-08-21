using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PlayerInputHandle inputHandle;
    public GameObject goPanel;

    private void Awake()
    {
        inputHandle = FindObjectOfType<PlayerInputHandle>();
    }

    public void closeBtn()
    {
        goPanel.SetActive(false);
        MusicCtrl.instance.autoPlay();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputHandle.lookSensitivity = 1;
    }

    public void quitgame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
