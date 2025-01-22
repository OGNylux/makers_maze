using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer player;
    public RectTransform Panel;
    void Start()
    {        
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        Panel.gameObject.SetActive(true);
    }
}
