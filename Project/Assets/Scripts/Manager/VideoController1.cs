using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager1 : MonoBehaviour
{
    public VideoPlayer VideoPlayer2;
    public string videoURL2 = "https://users.sussex.ac.uk/~bc418/sanxingduipage/assets/videos/Sanxingdui02.mp4";

    public Text VideoTimeText2;
    public Slider VideoSlider2;

    private string VideoLengthString2;
    private float VideoLength2;

    void Start()
    {
        // 初始化第二个视频播放器
        if (VideoPlayer2 != null)
        {
            VideoPlayer2.source = VideoSource.Url;
            VideoPlayer2.url = videoURL2;

            VideoPlayer2.prepareCompleted += OnVideoPrepared;
            VideoPlayer2.loopPointReached += OnVideoFinished;
            VideoPlayer2.Prepare();
        }

        VideoSlider2.onValueChanged.AddListener(OnVideoSliderValueChange);
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        VideoLength2 = (float)vp.length;
        VideoLengthString2 = TurnTimeToString((int)VideoLength2);
        ResetUI();
        StartCoroutine(DelayForTimeText());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void OnPlayPauseButtonDown()
    {
        if (VideoPlayer2.isPlaying)
        {
            VideoPlayer2.Pause();
        }
        else
        {
            VideoPlayer2.Play();
        }
    }

    private IEnumerator DelayForTimeText()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (true)
        {
            if (VideoPlayer2.clip != null)
            {
                int currentTime = (int)VideoPlayer2.time;
                VideoTimeText2.text = TurnTimeToString(currentTime) + "/" + VideoLengthString2;
                VideoSlider2.SetValueWithoutNotify(Mathf.Clamp01((float)currentTime / VideoLength2));
            }
            yield return waitTime;
        }
    }

    private void OnVideoSliderValueChange(float arg0)
    {
        if (VideoLength2 > 0)
        {
            VideoPlayer2.time = arg0 * VideoLength2;
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        ResetUI();
    }

    private void ResetUI()
    {
        VideoSlider2.SetValueWithoutNotify(0f);
        VideoTimeText2.text = "00:00:00/" + VideoLengthString2;
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
