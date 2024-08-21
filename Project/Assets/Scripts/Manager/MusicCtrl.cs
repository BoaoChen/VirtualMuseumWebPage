using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour
{
    public static MusicCtrl instance;
    public AudioSource music;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        music = GetComponent<AudioSource>();
    }
    public void autoPlay()
    {
        music.Play();
    }
    public void pauseMusic()
    {
        music.Pause();
    }
}
