using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoQueue : MonoBehaviour
{
    public RectTransform Panel;
    public RawImage[] videoImages;
    public VideoPlayer[] videoPlayers;
    private RawImage currentVideoImage;
    private VideoPlayer currentVideoPlayer;
    private int currentVideoIndex = 0;

    void Start()
    {
        currentVideoImage = videoImages[0].GetComponent<RawImage>();
        currentVideoPlayer = videoPlayers[0].GetComponent<VideoPlayer>();
    }

    public void rewatchVideo()
    {
        Panel.gameObject.SetActive(false);
        currentVideoPlayer.Play();
    }

    public void nextVideo()
    {
        Panel.gameObject.SetActive(false);
        currentVideoImage.gameObject.SetActive(false);
        currentVideoIndex++;
        if (currentVideoIndex >= videoImages.Length)
        {
            currentVideoIndex = 0;
        }
        currentVideoImage = videoImages[currentVideoIndex].GetComponent<RawImage>();
        currentVideoPlayer = videoPlayers[currentVideoIndex].GetComponent<VideoPlayer>();
        currentVideoImage.gameObject.SetActive(true);
        currentVideoPlayer.Play();
    }
}
