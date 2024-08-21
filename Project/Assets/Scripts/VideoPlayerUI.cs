using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerUI : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放器组件
    public Button playPauseButton; // 播放/暂停按钮
    public Slider progressBar; // 进度条
    public Text currentTimeText; // 当前时间显示
    public Text totalTimeText; // 总时间显示

    private bool isPlaying = false;

    void Start()
    {
        // 初始化播放状态
        playPauseButton.onClick.AddListener(TogglePlayPause);
        progressBar.onValueChanged.AddListener(OnProgressBarChanged);

        // 初始化进度条和时间显示
        if (videoPlayer != null)
        {
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += (source) => {
                totalTimeText.text = FormatTime((float)videoPlayer.length);
                progressBar.maxValue = (float)videoPlayer.length;
            };
        }
    }

    void Update()
    {
        // 更新进度条和当前时间显示
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            progressBar.value = (float)videoPlayer.time;
            currentTimeText.text = FormatTime((float)videoPlayer.time);
        }
    }

    void TogglePlayPause()
    {
        // 切换播放/暂停状态
        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;
    }

    void OnProgressBarChanged(float value)
    {
        // 设置视频的播放时间
        if (videoPlayer != null && !videoPlayer.isPlaying)
        {
            videoPlayer.time = value;
        }
    }

    string FormatTime(float time)
    {
        // 格式化时间显示
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
