using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoPlayController : MonoBehaviour
{

    public GameObject PCWholeCanvas;
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button replayButton;
    public GameObject MenuScreen;
    public GameObject VideoScreen;
    public GameObject IdeaMaker1;
    public Button PlayGameButton;
    public GameObject NoUSBScreen;
    public GameObject CameraBoxView;
    //public Button NextButton;
    public GameObject usbobject;
    public UnityEvent onUSBInserted;
    public GameObject RotationPanel;
    public GameObject MovePanel;
    public GameObject RotationCircles;
    public GameObject MoveArrows;
    public GameObject Arm;
    public GameObject ViewPanel;
    public GameObject PanPanel;

    public GameObject ScaleError;
    public GameObject SupportError;
    public GameObject ExportSucess;
    public GameObject EstimatedPrintResult;

    public Button ViewButton;
    public Button PanButton;
    public Button MoveButton;
    public Button RotateButton;
    public Button ScaleButton;
    public Button SupportButton;
    public Button StartSlicingButton;
    public UnityEvent playbutoon;


    // Start is called before the first frame update
    void Start()
    {
        PCWholeCanvas.SetActive(false);
        playButton.onClick.AddListener(PlayVideo);
        replayButton.onClick.AddListener(ReplayVideo);
        videoPlayer.loopPointReached += OnVideoEnd;
        PlayGameButton.onClick.AddListener(PlayGame);
        RotationPanel.SetActive(false); RotationCircles.SetActive(false);
        MovePanel.SetActive(false); MoveArrows.SetActive(false);
        Arm.SetActive(false);
        ScaleError.SetActive(false);
        SupportError.SetActive(false);
        ExportSucess.SetActive(false);
        EstimatedPrintResult.SetActive(false);
        ViewPanel.SetActive(false);
        PanPanel.SetActive(false);

        ViewButton.enabled = false;
        PanButton.enabled = false;
        MoveButton.enabled = false;
        RotateButton.enabled = false;
        ScaleButton.enabled = false;
        SupportButton.enabled = false;
        StartSlicingButton.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayVideo()
    {
        VideoScreen.SetActive(true);
        MenuScreen.SetActive(false);
        videoPlayer.Play();

    }

    void ReplayVideo()
    {
        videoPlayer.Stop();
        videoPlayer.frame = 0;
        PlayVideo();
    }

    void OnPrepareCompleted(VideoPlayer player)
    {
        player.prepareCompleted -= OnPrepareCompleted; // Unsubscribe from the event
        player.Play();
        VideoScreen.SetActive(true);
    }

    void OnVideoEnd(VideoPlayer player)
    {
        MenuScreen.SetActive(true);
        VideoScreen.SetActive(false);

    }

    void PlayGame()
    {
        IdeaMaker1.SetActive(true);
        MenuScreen.SetActive(false);
        VideoScreen.SetActive(false);
        playbutoon.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == usbobject)
        {

            onUSBInserted.Invoke();

        }
    }
    public void USBInserted()
    {
        NoUSBScreen.SetActive(false);
        CameraBoxView.SetActive(true);
        onUSBInserted.Invoke();
    }
}
