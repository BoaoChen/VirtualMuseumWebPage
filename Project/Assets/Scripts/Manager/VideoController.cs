using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer VideoPlayer1;
    public string videoURL1 = "https://users.sussex.ac.uk/~bc418/sanxingduipage/assets/videos/Sanxingdui01.MP4";

    public Text VideoTimeText;
    public Slider VideoSlider;

    private string VideoLengthString;
    private float VideoLength;

    void Start()
    {
        // 初始化第一个视频播放器
        if (VideoPlayer1 != null)
        {
            VideoPlayer1.source = VideoSource.Url;
            VideoPlayer1.url = videoURL1;

            VideoPlayer1.prepareCompleted += OnVideoPrepared;
            VideoPlayer1.loopPointReached += OnVideoFinished;
            VideoPlayer1.Prepare();
        }

        VideoSlider.onValueChanged.AddListener(OnVideoSliderValueChange);
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        VideoLength = (float)vp.length;
        VideoLengthString = TurnTimeToString((int)VideoLength);
        ResetUI();
        StartCoroutine(DelayForTimeText());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void OnPlayPauseButtonDown()
    {
        if (VideoPlayer1.isPlaying)
        {
            VideoPlayer1.Pause();
        }
        else
        {
            VideoPlayer1.Play();
        }
    }

    private IEnumerator DelayForTimeText()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (true)
        {
            if (VideoPlayer1.clip != null)
            {
                int currentTime = (int)VideoPlayer1.time;
                VideoTimeText.text = TurnTimeToString(currentTime) + "/" + VideoLengthString;
                VideoSlider.SetValueWithoutNotify(Mathf.Clamp01((float)currentTime / VideoLength));
            }
            yield return waitTime;
        }
    }

    private void OnVideoSliderValueChange(float arg0)
    {
        if (VideoLength > 0)
        {
            VideoPlayer1.time = arg0 * VideoLength;
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        ResetUI();
    }

    private void ResetUI()
    {
        VideoSlider.SetValueWithoutNotify(0f);
        VideoTimeText.text = "00:00:00/" + VideoLengthString;
    }

    private string TurnTimeToString(int time)
    {
        int hour = Mathf.FloorToInt(time / 3600f);
        time = time - hour * 3600;

        int minute = Mathf.FloorToInt(time / 60f);
        time = time - minute * 60;

        int second = time;

        return hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
    }
}
